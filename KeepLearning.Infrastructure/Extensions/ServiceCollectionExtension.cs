using KeepLearning.Domain.Interfaces;
using KeepLearning.Infrastructure.Persistence;
using KeepLearning.Infrastructure.Repositories;
using KeepLearning.Infrastructure.Seeders;
using KeepLearning.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KeepLearning.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString;
            SetConnectionString(true, out connectionString);

            services.AddDbContext<KeepLearningDbContext>(options =>
                options.UseSqlServer(connectionString)
            );

            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.Stores.MaxLengthForKeys = 450;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<KeepLearningDbContext>();

            services.AddScoped<CountrySeeder>();

            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICountryService, CountryService>();
        }

        private static void SetConnectionString(bool isDevelop, out string connectionString)
        {
            if (isDevelop)
            {
                connectionString = GetEnvOrSetEmpty("ASPNETCORE_DEV_CONNECTION_STRING");
            } else
            {
                connectionString = GetEnvOrSetEmpty("ASPNETCORE_PROD_CONNECTION_STRING");
            }
        }

        private static string GetEnvOrSetEmpty(string name)
        {
            var env = Environment.GetEnvironmentVariable(name);

            if (env == null)
            {
                return "";
            }

            return env;
        }
    }
}
