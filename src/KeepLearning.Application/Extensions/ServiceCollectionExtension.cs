using FluentValidation;
using FluentValidation.AspNetCore;
using KeepLearning.Domain.Commands.CreateExamCountry;
using KeepLearning.Domain.Mappings;
using KeepLearning.Domain.Queries.GetCountries;
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

            services.AddValidatorsFromAssemblyContaining<CreateExamCountryCommand>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
