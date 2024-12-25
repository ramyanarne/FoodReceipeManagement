using FoodReceipeManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodReceipeManagement.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
        public static void ConfigureSqlServerContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["azuresqlserverconnection"];

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
