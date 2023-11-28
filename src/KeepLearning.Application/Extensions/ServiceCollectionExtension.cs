using FluentValidation;
using FluentValidation.AspNetCore;
using KeepLearning.Domain.Mappings;
using KeepLearning.Domain.Queries.GetCountries;
using KeepLearning.Domain.Commands.CreateTestCountry;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace KeepLearning.Domain.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ContinentMappingProfile));
            services.AddAutoMapper(typeof(CountryMappingProfile));

            services.AddMediatR(typeof(GetCountriesQuery));

            services.AddValidatorsFromAssemblyContaining<CreateTestCountryCommand>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
