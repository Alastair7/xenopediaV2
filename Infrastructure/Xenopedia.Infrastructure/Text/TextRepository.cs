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
            using var connection = new MySqlConnection(databaseManager.GetConnectionString());

            IEnumerable<TextEntity>? result = null;

            var sql = "SELECT * FROM text;";

            result = await connection.QueryAsync<TextEntity>(sql);

            return result;
        }

        public async Task<TextEntity> GetTextById(long idText)
        {
            using var connection = new MySqlConnection(databaseManager.GetConnectionString());
            TextEntity? result = null;
            var sql = "SELECT * FROM text WHERE IdText = @idText";

            result = await connection.QueryFirstOrDefaultAsync<TextEntity>(sql, new { idText });

            return result;
        }

        public Task<bool> InsertText(TextEntity text)
        {
            throw new NotImplementedException();
        }
    }
}
