using FetchFood.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using FetchFood.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FluentResults;

namespace FetchFood.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabaseService(this IServiceCollection services, IConfiguration configuration)
        {
            var coreStringConnection = configuration.GetConnectionString("CoreConnection");
            var restaurantStringConnection = configuration.GetConnectionString("RestaurantConnection");
            var jwtSecret = configuration.GetSection("JwtConfig").GetSection("secret").Value;

            services.AddDbContext<CoreDbContext>((serviceProvider, options) =>
            {
                options.UseLazyLoadingProxies().UseNpgsql(coreStringConnection);
            });

            services.AddDbContext<FetchFoodDbContext>(
                (serviceProvider, options) =>
                {
                    var httpContextAccessor = serviceProvider.GetService<IHttpContextAccessor>();
                    string? restaurantId = httpContextAccessor?.HttpContext?.Request.Headers["RestaurantId"].ToString();
                    if (!string.IsNullOrEmpty(restaurantId)){
                        restaurantStringConnection = restaurantStringConnection?.Replace("devdb", restaurantId);
                    }
                        options.UseLazyLoadingProxies().UseNpgsql(restaurantStringConnection);
                });

            services.AddIdentityCore<CustomIdentityUser>(
                (options) => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole<int>>()
                .AddEntityFrameworkStores<FetchFoodDbContext>()
                .AddEntityFrameworkStores<CoreDbContext>()
                .AddDefaultTokenProviders()
                .AddSignInManager();

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(token =>
            {
                token.RequireHttpsMetadata = false;
                token.SaveToken = true;
                token.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtSecret)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };

                token.Events = new JwtBearerEvents
                {
                    OnChallenge = async context =>
                    {
                        Result unauthorized = Result.Fail("Sem autenticação.");
                        context.HandleResponse();
                        context.Response.StatusCode = 401;
                        await context.Response.WriteAsJsonAsync(unauthorized);
                    },
                    OnForbidden = async context => {
                        Result forbidden = Result.Fail("Sem permissão.");
                        context.Response.StatusCode = 403;
                        await context.Response.WriteAsJsonAsync(forbidden);
                    }
                };
            })
            .AddIdentityCookies();

            services.Configure<IdentityOptions>(options => options.User.RequireUniqueEmail = true);

            return services;
        }
    }
}
