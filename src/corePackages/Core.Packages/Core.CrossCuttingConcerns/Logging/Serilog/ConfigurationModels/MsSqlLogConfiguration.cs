namespace Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels
{
    public class MsSqlLogConfiguration
    {
        public MsSqlLogConfiguration()
        {
            ConnectionString = string.Empty;
            TableName = string.Empty;
            AutoCreateSqlTable = false;
        }

        public MsSqlLogConfiguration(string connectionString, string tableName, bool autoCreateSqlTable)
        {
            ConnectionString = connectionString;
            TableName = tableName;
            AutoCreateSqlTable = autoCreateSqlTable;
        }

        public string ConnectionString { get; set; }
        public string TableName { get; set; }
        public bool AutoCreateSqlTable { get; set; }
    }
}
