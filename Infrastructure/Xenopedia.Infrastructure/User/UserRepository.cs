using Dapper;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System.Data;
using Xenopedia.Commons.Database;
using Xenopedia.Entities.Entity.User;
using static System.Net.Mime.MediaTypeNames;

namespace Xenopedia.Infrastructure.User
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseManager dbManager;

        public UserRepository(IDatabaseManager dbManager) 
        {
            this.dbManager = dbManager;
        }

        public async Task<UserEntity> GetUser(string username)
        {
            MySqlConnection connection = dbManager.ConnectDB();
            UserEntity? userEntity = null;

            try 
            {

                if (connection.State != ConnectionState.Open) { connection.Open(); }
                string sql = "SELECT * FROM users WHERE username = @username";

                userEntity = await connection.QueryFirstOrDefault(sql, new { username });

            }
            catch 
            {
                // Add logs here
            }
            finally 
            {
                connection.Close();
            }

            return userEntity ?? new UserEntity();
        }
    }
}
