using Domain.Interfaces;
using Infrastructure.Data.Seeders;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING_KL_DB");

            services.AddDbContext<KeepLearningDbContext>(options =>
                options.UseSqlServer(connectionString)
            );

            services.AddScoped<IContinentRepository, ContinentRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICountryService, CountryService>();

            services.AddScoped<ContinentSeeder>();
            services.AddScoped<CountrySeeder>();

            return services;
        }

    }
}
