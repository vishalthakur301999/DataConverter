using System;

namespace DataConverter.Setup.Database
{
    public class SqlConnectionString
    {
        private readonly string _connectionString;
        private readonly DatabaseConfig _databaseConfig;
        private readonly SecretConfig _deploymentUserSecrets;
        private readonly SecretConfig _userSecrets;
        
        public SqlConnectionString (string connectionString, DatabaseConfig databaseConfig, 
            SecretConfig deploymentUserSecrets = null, SecretConfig userSecrets = null)
        {
            _connectionString = connectionString;
            _databaseConfig = databaseConfig;
            _deploymentUserSecrets = deploymentUserSecrets;
            _userSecrets = userSecrets;
        }
        public bool IsInMemory => string.IsNullOrEmpty(_databaseConfig.Name) || string.Equals(_databaseConfig.Name, "MEMORY", 
            StringComparison.OrdinalIgnoreCase);

        public string DeploymentConnectionString => string.Format(_connectionString, _databaseConfig.DataSource,
            _databaseConfig.Name,
            _databaseConfig.UseWindowsAuthentication ? "True" : "False",
            _deploymentUserSecrets?.Username ?? string.Empty, _deploymentUserSecrets?.Password ?? string.Empty);
        
        public string ConnectionString => string.Format(_connectionString, _databaseConfig.DataSource, _databaseConfig.Name, 
            _databaseConfig.UseWindowsAuthentication ? "True" : "False", 
            _userSecrets?.Username ?? string.Empty, _userSecrets?.Password ?? string.Empty);
    }
    
}