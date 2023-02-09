using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Xenopedia.Commons.Database
{
    public class DatabaseManager : IDatabaseManager
    {
        private readonly IConfiguration config;

        public DatabaseManager(IConfiguration config) 
        {
            this.config = config;
        }

        public string GetConnectionString()
        {
            string connectionString = config.GetConnectionString("MYSQL_DB_CONN") ?? string.Empty;
            return connectionString;
        }
    }
}
