using System.Data.SqlClient;

namespace ProjectX.Models
{
    public class PizzaModel : IDisposable
    {
        private readonly SqlConnection _connection;

        public PizzaModel()
        {
            const string strConn = "Data Source=ANDRADEDELL;Initial Catalog=BDPizza;Integrated Security=True;";
            _connection = new SqlConnection(strConn);
            _connection.Open();
        }

        public void Dispose()
        {
            _connection.Close();
        }

        public void Create(Pizza pizza)
        {
            var cmd = new SqlCommand();
            cmd.Connection = _connection;
            cmd.CommandText = @"INSERT INTO Pizza (Nome, Ingredientes, Valor) VALUES (@nome, @ingredientes, @valor)";

            cmd.Parameters.AddWithValue("@nome", pizza.GetNome());
            cmd.Parameters.AddWithValue("@ingredientes", pizza.GetIngredientes());
            cmd.Parameters.AddWithValue("@valor", pizza.GetValor());

            cmd.ExecuteNonQuery();
        }

        public void Update(Pizza pizza)
        {
            var cmd = new SqlCommand();
            cmd.Connection = _connection;
            cmd.CommandText = @"UPDATE Pizza SET Nome = @nome, Ingredientes = @ingredientes, Valor = @valor WHERE IdPizza = @id";

            cmd.Parameters.AddWithValue("@nome", pizza.GetNome());
            cmd.Parameters.AddWithValue("@ingredientes", pizza.GetIngredientes());
            cmd.Parameters.AddWithValue("@valor", pizza.GetValor());
            cmd.Parameters.AddWithValue("@id", pizza.GetIdPizza());

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            var cmd = new SqlCommand();
            cmd.Connection = _connection;
            cmd.CommandText = @"DELETE FROM Pizza WHERE IdPizza = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        public List<Pizza> Read()
        {
            List<Pizza> lista = new List<Pizza>();

            var cmd = new SqlCommand();
            cmd.Connection = _connection;
            cmd.CommandText = @"SELECT * FROM Pizza";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var pizza = new Pizza(
                    (int)reader["IdPizza"],
                    (string)reader["Nome"],
                    (string)reader["Ingredientes"],
                    (int)reader["Valor"]
                );

                lista.Add(pizza);
            }

            return lista;
        }
    }
}