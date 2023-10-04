using KeepLearning.Domain.Interfaces;
using KeepLearning.Infrastructure.Persistence;
using KeepLearning.Infrastructure.Repositories;
using KeepLearning.Infrastructure.Seeders;
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
            services.AddDbContext<KeepLearningDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("KeepLearning"))
            );

            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.Stores.MaxLengthForKeys = 450;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<KeepLearningDbContext>();

            services.AddScoped<CountrySeeder>();

            services.AddScoped<ICountryRepository, CountryRepository>();
        }
    }
}
