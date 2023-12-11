using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace KeepLearning.MVC.HealthChecker
{
    public class EnvironmentHealthChecker : IHealthCheck
    {

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var environment = Environment.GetEnvironmentVariable("CONNECTION_STRING_KL_DB");

            if (environment is not null)
            {
                return Task.FromResult(HealthCheckResult.Healthy());
            }
            else
            {
                return Task.FromResult(HealthCheckResult.Unhealthy());
            }
        }
    }
}