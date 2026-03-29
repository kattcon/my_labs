using backend_lab_A85112.Models;
using backend_lab_A85112.Repositories;
namespace backend_lab.Services
{
    public class CountryService
    {
        // Instancia del repositorio que se encarga de acceder a la base de datos
        private readonly CountryRepository countryRepository;
        // Constructor del servicio
        public CountryService()
        {
            countryRepository = new CountryRepository();
        }
        // Método para obtener la lista de países
        public List<CountryModel> GetCountries()
        {
            // Add any missing business logic when it is neccesary
            return countryRepository.GetCountries();
        }

        public string CreateCountry(CountryModel country)
        {
            var result = string.Empty;
            try
            {
                // Llama al repositorio para insertar el país
                var isCreated = countryRepository.CreateCountry(country);
                // Si no se creó correctamente, devuelve mensaje de error
                if (!isCreated)
                {
                    result = "Error al crear el país";
                }
            }
            catch (Exception)
            {
                // Si ocurre una excepción (error inesperado)
                result = "Error creando país";
            }
            return result;
        }
    }
}
