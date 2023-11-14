using CompraRápida.Models;
using MySql.Data.MySqlClient;

namespace CompraRápida.repositorio
{
    public class ClienteService
    {
        private readonly string _connectionString;

        public ClienteService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void InserirCliente(Cliente cliente)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Cliente (cpf, email, senha, nomeCliente) VALUES (@cpf, @email, @senha, @nomeCliente)";

                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                command.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = cliente.CPF;
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = cliente.Email;
                command.Parameters.Add("@senha", MySqlDbType.VarChar).Value = cliente.Senha;
                command.Parameters.Add("@nomeCliente", MySqlDbType.VarChar).Value = cliente.NomeCliente;

                command.ExecuteNonQuery();
            }
        }
    }
}
