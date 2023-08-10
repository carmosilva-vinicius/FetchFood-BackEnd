using FetchFood.Data.Repositories;
using FetchFood.Entities.Interfaces;
using FetchFood.UseCases.Services;
using FetchFood.UseCases.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FetchFood.Data
{
    public static class ServiceDependency
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
