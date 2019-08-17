using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace GJJA.RegistraVoce.DataAccess.Utils
{
    public class DbUtils
    {
        public static DbConnection CreateConnection()
        {
            DbConnection connection = new MySqlConnection("Server=localhost;Database=registravoce;Uid=root;Pwd=aluno;");
            connection.Open();
            return connection;
        }

        public static void CloseConnection(DbConnection conn)
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}