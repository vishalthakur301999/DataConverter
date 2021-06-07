using Microsoft.Extensions.Configuration;

namespace DataConverter.Setup.Database
{
    public static class SqlConfigurationExtensions
    {
        public static string GetDatabaseName(this IConfiguration configuration)
        {
            return configuration.GetSection<DatabaseConfig>("Database").Name;
        }

        public static SqlConnectionString GetSqlConfiguration(this IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");
            var databaseConfig = configuration.GetSection<DatabaseConfig>("Database");
            var deploymentUserSecrets = configuration.GetSection<SecretConfig>("mssql:deployment");
            var userSecrets = configuration.GetSection<SecretConfig>("mssql");
            return new SqlConnectionString(connectionString, databaseConfig, deploymentUserSecrets, userSecrets);
        }
    }
}