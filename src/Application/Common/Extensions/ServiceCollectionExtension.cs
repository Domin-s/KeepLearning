using FluentValidation;
using FluentValidation.AspNetCore;
using Application.Common.Mappings;
using Application.Country.Queries.GetAllCountries;
using Domain.Commands.CreateExamCountry;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ContinentMappingProfile));
            services.AddAutoMapper(typeof(CountryMappingProfile));

            services.AddMediatR(typeof(GetAllCountriesQuery));

            services.AddValidatorsFromAssemblyContaining<CreateExamCountryCommand>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
