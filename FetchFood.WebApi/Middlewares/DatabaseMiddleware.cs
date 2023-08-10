using FetchFood.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FetchFood.WebApi.Middlewares
{
    public static class DatabaseMiddleware
    {
        public static WebApplication EnsureMigration(this WebApplication webApp)
        {
            using (var scope = webApp.Services.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<CoreDbContext>())
                {
                    try
                    {
                        context.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        throw;
                    }
                }
            }
            return webApp;
        }
    }
}
