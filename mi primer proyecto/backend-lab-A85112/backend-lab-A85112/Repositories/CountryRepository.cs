// Importa los modelos del proyecto (CountryModel)
using backend_lab_A85112.Models;
// Importa Dapper para ejecutar consultas SQL de forma sencilla
using Dapper;
// Importa clases para conexión a SQL Server
using System.Data.SqlClient;

// Define el namespace donde está el repositorio
namespace backend_lab_A85112.Repositories
{
    // Clase que se encarga de acceder a la base de datos (patrón Repository)
    public class CountryRepository
    {
        // Variable privada que almacena la cadena de conexión a la base de datos
        private readonly string _connectionString;
        // Constructor de la clase
        public CountryRepository()
        {
            // Crea un builder para acceder a la configuración del proyecto
            var builder = WebApplication.CreateBuilder();
            // Obtiene la cadena de conexión llamada "CountryContext" desde appsettings.json
            _connectionString = builder.Configuration.GetConnectionString("CountryContext");
        }

        // Método para obtener la lista de países desde la base de datos
        public List<CountryModel> GetCountries()
        {
            // Crea una conexión a la base de datos usando la cadena de conexión
            using var connection = new SqlConnection(_connectionString);
            // Consulta SQL para traer todos los registros de la tabla Country
            string query = "SELECT * FROM dbo.Country";
            // Ejecuta la consulta con Dapper y mapea los resultados a una lista de CountryModel
            return connection.Query<CountryModel>(query).ToList();
        }

        // Método para insertar un nuevo país en la base de datos
        public bool CreateCountry(CountryModel country)
        {
            // Abre conexión a la base de datos
            using var connection = new SqlConnection(_connectionString);
            // Consulta SQL para insertar un nuevo registro en la tabla Country
            var query = @"INSERT INTO [dbo].[Country] ([Name],[Language],[Continent])
                            VALUES(@Name, @Language, @Continent)";
            // Ejecuta la consulta usando parámetros (evita SQL Injection)
            var affectedRows = connection.Execute(query, new
            {
                Name = country.Name,
                Language = country.Language,
                Continent = country.Continent
            });
            // Retorna true si al menos una fila fue afectada (inserción exitosa)
            return affectedRows >= 1;
        }
    }
}