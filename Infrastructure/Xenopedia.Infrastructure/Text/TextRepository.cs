using Dapper;
using MySql.Data.MySqlClient;
using Xenopedia.Commons.Database;
using Xenopedia.Entities.Entity.Text;

namespace Xenopedia.Infrastructure.Text
{
    public class TextRepository : ITextRepository
    {
        private readonly IDatabaseManager databaseManager;

        public TextRepository(IDatabaseManager databaseManager) 
        {
            this.databaseManager = databaseManager;
        }

        public async Task<IEnumerable<TextEntity>> GetAllText()
        {
            using var connection = new MySqlConnection("server=aws.connect.psdb.cloud;user=di6x5rp8ve6g5xm08utr;database=xenopedia_db;port=3306;password=pscale_pw_GonCS6PVOcXywfBSTtVgDjqnSKcJCAQMB2GtwfgGX2p;SslMode=VerifyFull");
            IEnumerable<TextEntity> result;

            var sql = "SELECT * FROM text;";

            result = await connection.QueryAsync<TextEntity>(sql);

            return result;
        }

        public async Task<TextEntity> GetTextById(long idText)
        {
            //using var connection = new MySqlConnection(databaseManager.GetConnectionString());
            using var connection = new MySqlConnection("server=aws.connect.psdb.cloud;user=di6x5rp8ve6g5xm08utr;database=xenopedia_db;port=3306;password=pscale_pw_GonCS6PVOcXywfBSTtVgDjqnSKcJCAQMB2GtwfgGX2p;SslMode=VerifyFull");
            TextEntity? result = null;
            var sql = "SELECT * FROM text WHERE IdText = @idText";

            result = await connection.QueryFirstOrDefaultAsync<TextEntity>(sql, new { idText });

            return result;
        }

        public async Task<bool> InsertText(TextEntity text)
        {
            using var connection = new MySqlConnection("server=aws.connect.psdb.cloud;user=di6x5rp8ve6g5xm08utr;database=xenopedia_db;port=3306;password=pscale_pw_GonCS6PVOcXywfBSTtVgDjqnSKcJCAQMB2GtwfgGX2p;SslMode=VerifyFull");
            bool inserted;

            var sql = "INSERT INTO text () VALUES ()";

            inserted = await connection.ExecuteAsync(sql) > 0;

            return inserted;
        }
    }
}
