using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyHDL.LearningCS.VII.BaseDeDatos
{
    public class BeerDB : BaseDeDatos_DB
    {
        public BeerDB(string server, string db) :
            base(server, db)
        {
            
        }

        public List<Beer> GetAll()
        {
            // metodo del padre
            Connect();
            List<Beer> beers = new List<Beer>();
            // la consulta
            string query = "SELECT Id, Name, BrandId FROM BEER";
            SqlCommand command = new SqlCommand(query, _connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int brandId = reader.GetInt32(2);

                beers.Add(new Beer(id, name, brandId));
            }

            Close();

            return beers;
        }

        public Beer Get(int id)
        {
            Connect();
            Beer beer = null;
            string query = "SELECT Id, Name, BrandId FROM BEER " +
                "WHERE id = @id";

            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string name = reader.GetString(1);
                int brandId = reader.GetInt32(2);
                beer = new Beer(id, name, brandId);
            }

            Close();

            return beer;
        }

        public void Add(Beer beer)
        {
            Connect();

            // En VALUES se recomienda no usar string interpolation $"{}"
            // porque queda expuesto a SQL injection, para eso se usan
            // @nameVariable para saber el nombre de la variable a pasar
            string query = "INSERT INTO Beer(Name, BrandId) " +
                "VALUES(@name, @brandId)";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@name", beer.Name);
            command.Parameters.AddWithValue("@brandId", beer.BrandId);
            command.ExecuteNonQuery();

            Close();
        }

        public void Edit(Beer beer)
        {
            Connect();

            string query = "UPDATE Beer SET name = @name, brandId = @brandId " +
                "WHERE id = @id";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@name", beer.Name);
            command.Parameters.AddWithValue("@brandId", beer.BrandId);
            command.Parameters.AddWithValue("@id", beer.Id);
            command.ExecuteNonQuery();

            Close();
        }

        public void Delete(int id)
        {
            Connect();

            string query = "DELETE FROM Beer WHERE id = @id";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();

            Close();
        }
    }
}
