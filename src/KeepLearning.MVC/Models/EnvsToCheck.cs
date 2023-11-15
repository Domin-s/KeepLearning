namespace KeepLearning.MVC.Models
{
    public class EnvsToCheck
    {
        string? EnvironmentValue { get; set; }
        string? DbDataSource { get; set; }
        string? DbServer { get; set; }
        string? DbInitialCatalog { get; set; }
        string? DbTruestServerCertificate { get; set; }
        string? DbUserId { get; set; }
        string? DbUserPassword { get; set; }

        public EnvsToCheck()
        {
            this.EnvironmentValue = Environment.GetEnvironmentVariable("ENVIRONMENT");
            this.DbDataSource = Environment.GetEnvironmentVariable("DB_DATA_SOURCE");
            this.DbServer = Environment.GetEnvironmentVariable("DB_SERVER");
            this.DbInitialCatalog = Environment.GetEnvironmentVariable("DB_INITIAL_CATALOG");
            this.DbTruestServerCertificate = Environment.GetEnvironmentVariable("DB_TRUST_SERVER_CERTIFICATE");
            this.DbUserId = Environment.GetEnvironmentVariable("DB_USER_ID");
            this.DbUserPassword = Environment.GetEnvironmentVariable("DB_USER_PASSWORD");
        }

        public (bool, string) CheckLocalEnvironment()
        {

            if (DbDataSource is not null &&
                DbInitialCatalog is not null &&
                DbTruestServerCertificate is not null &&
                DbUserId is not null &&
                DbUserPassword is not null
            )
            {
                return (true, "Evrything is OK!");
            }

            return (false, CreateMessage());
        }

        public (bool, string) CheckProdEnvironment()
        {

            if (DbServer is not null &&
                DbInitialCatalog is not null &&
                DbTruestServerCertificate is not null &&
                DbUserId is not null &&
                DbUserPassword is not null)
            {
                return (true, "Evrything is ok");
            }

            return (false, CreateMessage());
        }

        private string CreateMessage()
        {
            var message = "";

            if (EnvironmentValue == "production") message += "EnvironmentValue is production \n";
            else if (EnvironmentValue == "develop") message += "EnvironmentValue is develop \n";
            else message += "EnvironmentValue is empty \n";

            if (DbDataSource is null) message += "DbDataSource is empty \n";
            if (DbServer is null) message += "DbServer is empty \n";
            if (DbInitialCatalog is null) message += "DbInitialCatalog is empty \n";
            if (DbTruestServerCertificate is null) message += "DbTruestServerCertificate is empty \n";
            if (DbUserId is null) message += "DbUserId is empty \n";
            if (DbUserPassword is null) message += "DbUserPassword is empty \n";

            return message;
        }
    }
}