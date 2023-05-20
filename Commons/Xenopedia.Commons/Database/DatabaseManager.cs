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

        public MySqlConnection ConnectDB()
        {
            string connectionString = config.GetValue<string>("Database:ConnectionString") ?? string.Empty;

            return new MySqlConnection(connectionString);
        }
    }
}
