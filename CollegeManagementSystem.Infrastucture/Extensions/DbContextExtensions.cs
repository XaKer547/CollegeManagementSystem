using CollegeManagementSystem.Infrastucture.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CollegeManagementSystem.Infrastucture.Extensions
{
    public static class DbContextExtensions
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CollegeManagementSystemDbContext>(options =>
            {
#if true
                options.UseNpgsql(configuration.GetConnectionString("SmartCollegeConnection"), b => b.MigrationsAssembly("CollegeManagementSystem.Infrastucture.Postgres"));
#else
                options.UseNpgsql(configuration.GetConnectionString("PgLocalConnection"), b => b.MigrationsAssembly("CollegeManagementSystem.Infrastucture.Postgres"));
#endif
            });
        }
    }
}
