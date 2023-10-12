using KeepLearning.Application.Mappings;
using KeepLearning.Application.Queries.GetCountries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace KeepLearning.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CountryMappingProfile));

            services.AddMediatR(typeof(GetCountriesQuery));
        }
    }
}
