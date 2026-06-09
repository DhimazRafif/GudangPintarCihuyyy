using MySql.Data.MySqlClient;

namespace GudangPintarKPL.ConfigDatabase
{
    public class DBConnection
    {
        private static DBConnection _instance;

        private readonly string _connectionString = "server=localhost;port=3306;uid=root;pwd=;database=gudangpintar2";

        private DBConnection() { }

        public static DBConnection GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DBConnection();
            }

            return _instance;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
