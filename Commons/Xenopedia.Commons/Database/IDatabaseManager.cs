using MySql.Data.MySqlClient;

namespace Xenopedia.Commons.Database
{
    public interface IDatabaseManager
    {
        MySqlConnection ConnectDB();
    }
}
