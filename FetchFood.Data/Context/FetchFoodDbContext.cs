using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FetchFood.Entities;
using FetchFood.Data.EntityConfiguration;

namespace FetchFood.Data.Context
{
    public class FetchFoodDbContext : IdentityDbContext<CustomIdentityUser,
        IdentityRole<int>, int>
    {
        public FetchFoodDbContext(DbContextOptions<FetchFoodDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ItemConfiguration());
            builder.ApplyConfiguration(new AddressConfiguration());

            base.OnModelCreating(builder);
            builder.HasDefaultSchema("public");
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });
            
            string adminEmail = "admin@fetchfood.com";
            CustomIdentityUser admin = new CustomIdentityUser
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = adminEmail,
                NormalizedEmail = adminEmail.ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 1,
                AddressId = null,
                CompleteName = "Admin",
            };

            PasswordHasher<CustomIdentityUser> hasher = new PasswordHasher<CustomIdentityUser>();

            admin.PasswordHash = hasher.HashPassword(admin, "1!Senha2@Forte3#");

            builder.Entity<CustomIdentityUser>().HasData(admin);
            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { RoleId = 1, UserId = 1 }
                );

        }

    }
}
