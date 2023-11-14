using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;



namespace CompraRápida.DbContext
{
    public class DatabaseService
    {
        private string strConexao;
        private MySqlConnection conexao;

        public DatabaseService(IConfiguration configuration)
        {
            strConexao = configuration.GetConnectionString("DefaultConnection");
            conexao = new MySqlConnection(strConexao);

            conexao.Open();
        }
       
    }
}
