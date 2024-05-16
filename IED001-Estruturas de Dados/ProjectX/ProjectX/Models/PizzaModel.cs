using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace ProjectX.Models
{
    public class PizzaModel : IDisposable
    {
        private SqlConnection connection;

        public PizzaModel()
        {
            string strConn = "Data Source=ANDRADEDELL;Initial Catalog=BDPizza;Integrated Security=True;";
            connection = new SqlConnection(strConn);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        public void Create(Pizza pizza)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO Pizza (Nome, Ingredientes, Valor) VALUES (@nome, @ingredientes, @valor)";

            cmd.Parameters.AddWithValue("@nome", pizza.Nome);
            cmd.Parameters.AddWithValue("@ingredientes", pizza.Ingredientes);
            cmd.Parameters.AddWithValue("@valor", pizza.Valor);

            cmd.ExecuteNonQuery();
        }

        public void Update(Pizza pizza)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE Pizza SET Nome = @nome, Ingredientes = @ingredientes, Valor = @valor WHERE IdPizza = @id";

            cmd.Parameters.AddWithValue("@nome", pizza.Nome);
            cmd.Parameters.AddWithValue("@ingredientes", pizza.Ingredientes);
            cmd.Parameters.AddWithValue("@valor", pizza.Valor);
            cmd.Parameters.AddWithValue("@id", pizza.IdPizza);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"DELETE FROM Pizza WHERE IdPizza = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        public List<Pizza> Read()
        {
            List<Pizza> lista = new List<Pizza>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM Pizza";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Pizza pizza = new Pizza();
                pizza.IdPizza = (int)reader["IdPizza"];
                pizza.Nome = (string)reader["Nome"];
                pizza.Ingredientes = (string)reader["Ingredientes"];
                pizza.Valor = (int)reader["Valor"];

                lista.Add(pizza);
            }

            return lista;
        }
    }
}