using KeepLearning.MVC.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace KeepLearning.MVC.HealthChecker
{
    public class EnvironmentHealthChecker : IHealthCheck
    {
        private EnvsToCheck envsToCheck = new EnvsToCheck();

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var (isOkEnvironment, message) = CheckEnvironments();

            if (isOkEnvironment)
            {
                return Task.FromResult(HealthCheckResult.Healthy(message));
            }
            else
            {
                return Task.FromResult(HealthCheckResult.Unhealthy(message));
            }
        }

        private (bool, string) CheckEnvironments()
        {
            var environment = Environment.GetEnvironmentVariable("ENVIRONMENT");

            if (environment == "production")
            {
                return envsToCheck.CheckProdEnvironment();
            }
            else if (environment == "develop")
            {
                return envsToCheck.CheckLocalEnvironment();
            }

            return (false, "Hosting environment :" + environment);
        }
    }

}