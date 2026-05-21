using MySql.Data.MySqlClient;
using System.Data;

namespace AgroSistema.Repositories
{
    public static class Conexao
    {
        // Ajuste a string de conexão conforme seu ambiente
        private static readonly string _connectionString =
            "Server=localhost;Database=AgroSistema;Uid=root;Pwd=;";

        public static IDbConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
