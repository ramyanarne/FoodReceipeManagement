using FoodReceipeManagement.Controllers;
using FoodReceipeManagement.Core.Contracts;
using FoodReceipeManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodReceipeManagement.Core
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication webApplication)
        {
            using (var scope = webApplication.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                       var logger = scope.ServiceProvider.GetRequiredService<ILoggerManager>();
                       logger.LogError($"Database Migrations Failed {ex.Message}");
                       throw;
                    }
                }
            }
            return webApplication;
        }
    }
}
