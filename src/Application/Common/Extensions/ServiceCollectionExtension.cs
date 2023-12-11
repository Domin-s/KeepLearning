using FluentValidation;
using FluentValidation.AspNetCore;
using Application.Common.Mappings;
using Domain.Commands.CreateExamCountry;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Common.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ContinentMappingProfile));
            services.AddAutoMapper(typeof(CountryMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateExamCountryCommand>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
        }
    }
}
