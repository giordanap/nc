using System;
using System.Data.SqlClient;


namespace UdemyHDL
{
    // Esta vendria a ser una clase comun, porque en la siguientes
    // sera una clase abstracta porque tendra una funcionalidad
    // que voy a reutilizar

    // Cambiamos a clase abstracto porque la vamos a reutilizar en clases hijas
    // que heredan, ya que esta ya tiene la abtraccion de tener la conexion, que
    // es la misma para cualquier entidad; para las marcas, cervezas, etc.
    // Ojo, un posible error que salte con este cambio se deba a que no se puede
    // crear objetos con una clase abstracta
    public abstract class BaseDeDatos_DB
    {
        private string _connectionstring;
        // Variables protegidas para que sus hijos puedan utilizarla,
        // diferente a una clase privada que solo la usa la clase
        // Además, intalamos el paquete SqlConnection
        protected SqlConnection _connection;

        public BaseDeDatos_DB(string server, string db, string user, string password)
        {
            _connectionstring = $"Data Source={server}; Initial Catalog={db}" +
                $"User={user}; Password={password}";
        }

        public BaseDeDatos_DB(string server, string db)
        {
            // Se especifica la conexion confiable
            // https://www.connectionstrings.com/sql-server-2019/
            _connectionstring = $"Data Source={server}; Initial Catalog={db}; Trusted_Connection=True";
        }

        public void Connect()
        {
            _connection = new SqlConnection(_connectionstring);
            _connection.Open();
        }

        public void Close()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            _connection.Close();
        }
    }
}
