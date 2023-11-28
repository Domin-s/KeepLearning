using FluentValidation;
using FluentValidation.AspNetCore;
using KeepLearning.Application.Common.Mappings;
using KeepLearning.Application.Country.Queries.GetCountries;
using KeepLearning.Domain.Commands.CreateExamCountry;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace KeepLearning.Application.Common.Extensions
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
