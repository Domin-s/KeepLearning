using FluentValidation;
using FluentValidation.AspNetCore;
using KeepLearning.Domain.Mappings;
using KeepLearning.Domain.Queries.GetCountries;
using KeepLearning.Domain.Queries.CreateTestCountry;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace KeepLearning.Domain.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CountryMappingProfile));

            services.AddMediatR(typeof(GetCountriesQuery));

            services.AddValidatorsFromAssemblyContaining<CreateTestCountryQuery>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
