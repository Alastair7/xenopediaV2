using Dapper;
using MySql.Data.MySqlClient;
using Xenopedia.Entities.Entity.User;
using static System.Net.Mime.MediaTypeNames;

namespace Xenopedia.Infrastructure.User
{
    public class UserRepository : IUserRepository
    {
        public async Task<UserEntity> GetUser(string username)
        {
            using var connection = new MySqlConnection("server=aws.connect.psdb.cloud;user=di6x5rp8ve6g5xm08utr;database=xenopedia_db;port=3306;password=pscale_pw_GonCS6PVOcXywfBSTtVgDjqnSKcJCAQMB2GtwfgGX2p;SslMode=VerifyFull");
            UserEntity userEntity;
            var sql = "INSERT INTO text () VALUES ()";

            userEntity = await connection.QueryFirstOrDefault(sql, new { username }) > 0;

            return userEntity;
        }
    }
}
