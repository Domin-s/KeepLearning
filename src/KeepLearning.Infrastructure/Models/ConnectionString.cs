namespace KeepLearning.Infrastructure.Models
{
    public static class ConnectionString
    {
        public static string GetDBConnectionString()
        {
            var environment = Environment.GetEnvironmentVariable("ENVIRONMENT");

            if (environment == "production")
            {
                return CreateProdConnectionString();
            }
            else
            {
                return CreateLocalConnectionString();
            }
        }

        private static string CreateLocalConnectionString()
        {
            var dbDataSource = Environment.GetEnvironmentVariable("DB_DATA_SOURCE");
            var dbInitialCatalog = Environment.GetEnvironmentVariable("DB_INITIAL_CATALOG");
            var dbTruestServerCertificate = Environment.GetEnvironmentVariable("DB_TRUST_SERVER_CERTIFICATE");
            var dbUserId = Environment.GetEnvironmentVariable("DB_USER_ID");
            var dbUserPassword = Environment.GetEnvironmentVariable("DB_USER_PASSWORD");

            var connectionString =
                $"Data Source={dbDataSource};" +
                $"Initial Catalog={dbInitialCatalog};" +
                $"TrustServerCertificate={dbTruestServerCertificate};" +
                $"User Id={dbUserId}; Password={dbUserPassword}";

            return connectionString;
        }

        private static string CreateProdConnectionString()
        {
            var dbServer = Environment.GetEnvironmentVariable("DB_SERVER");
            var dbInitialCatalog = Environment.GetEnvironmentVariable("DB_INITIAL_CATALOG");
            var dbTruestServerCertificate = Environment.GetEnvironmentVariable("DB_TRUST_SERVER_CERTIFICATE");
            var dbUserId = Environment.GetEnvironmentVariable("DB_USER_ID");
            var dbUserPassword = Environment.GetEnvironmentVariable("DB_USER_PASSWORD");

            var connectionString =
                $"Server={dbServer};" +
                $"Initial Catalog={dbInitialCatalog};" +
                $"TrustServerCertificate={dbTruestServerCertificate};" +
                $"User Id={dbUserId}; Password={dbUserPassword}" +
                "Persist Security Info=False;" +
                "MultipleActiveResultSets=False;" +
                "Encrypt=True;" +
                "Connection Timeout=30;";

            return connectionString;
        }
    }

}