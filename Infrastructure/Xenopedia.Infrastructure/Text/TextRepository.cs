using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using Xenopedia.Commons.Database;
using Xenopedia.Entities.Entity.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Xenopedia.Infrastructure.Text
{
    public class TextRepository : ITextRepository
    {
        private readonly IDatabaseManager dbManager;

        public TextRepository(IDatabaseManager databaseManager) 
        {
            this.dbManager = databaseManager;
        }

        public async Task<bool> DeleteText(long idText)
        {
            using var connection = new MySqlConnection("server=aws.connect.psdb.cloud;user=di6x5rp8ve6g5xm08utr;database=xenopedia_db;port=3306;password=pscale_pw_GonCS6PVOcXywfBSTtVgDjqnSKcJCAQMB2GtwfgGX2p;SslMode=VerifyFull");
            bool deleted;

            var sql = "DELETE text WHERE IdText = @idText";

            deleted = await connection.ExecuteAsync(sql, new { idText }) > 0;

            return deleted;
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
            TextEntity? result = null;
            MySqlConnection connection = dbManager.ConnectDB();

            if (connection.State != ConnectionState.Open) connection.Open();

            try 
            {
                var sql = TextRepositoryQueries.GetTextById;
                result = await connection.QueryFirstOrDefaultAsync<TextEntity>(sql, new { idText });
            }
            catch (Exception)
            {
                result = null;
            }
            finally
            {
                if (connection.State == ConnectionState.Open) connection.Close();
            }

            return result;
        }

        public async Task<bool> InsertText(TextEntity text)
        {
            bool inserted = false;

            MySqlConnection connection = dbManager.ConnectDB();

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            var transaction = connection.BeginTransaction();

            try 
            {
                    var sql = TextRepositoryQueries.InsertText;
                    inserted = await connection.ExecuteAsync(sql, text, transaction: transaction) > 0;
                    transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            finally 
            {
                if (connection.State == ConnectionState.Open) connection.Close();
            }

            return inserted;
        }

        public async Task<bool> TextExistsById(long idText)
        {
            using var connection = new MySqlConnection("server=aws.connect.psdb.cloud;user=di6x5rp8ve6g5xm08utr;database=xenopedia_db;port=3306;password=pscale_pw_GonCS6PVOcXywfBSTtVgDjqnSKcJCAQMB2GtwfgGX2p;SslMode=VerifyFull");
            bool exists;

            var sql = "SELECT EXISTS (SELECT 1 FROM text WHERE idText = @idText)";

            exists = await connection.QueryFirstOrDefaultAsync<bool>(sql, new { idText });

            return exists;
        }
    }
}
