using Infrastructure.Persistence;
using ZymLabs.NSwag.FluentValidation;

namespace Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddHealthChecks()
                .AddDbContextCheck<KeepLearningDbContext>();

            services.AddExceptionHandler<CustomExceptionHandler>();

            services.AddScoped(provider =>
            {
                var validationRules = provider.GetService<IEnumerable<FluentValidationRule>>();
                var loggerFactory = provider.GetService<ILoggerFactory>();

                return new FluentValidationSchemaProcessor(provider, validationRules, loggerFactory);
            });

            services.AddOpenApiDocument((configure, sp) =>
            {
                configure.Title = "CleanArchitecture API";


                // Add the fluent validations schema processor
                var fluentValidationSchemaProcessor =
                    sp.CreateScope().ServiceProvider.GetRequiredService<FluentValidationSchemaProcessor>();

                configure.SchemaSettings.SchemaProcessors.Add(fluentValidationSchemaProcessor);
            });

            return services;
        }

    }
}
