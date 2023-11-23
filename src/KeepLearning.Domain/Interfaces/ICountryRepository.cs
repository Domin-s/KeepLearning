using KeepLearning.Domain.Enteties;

namespace KeepLearning.Domain.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAll();
        Task<List<Country>> GetByContinents(string continents);
        Task<int> GetNumberOfCountries(string continents);
        Task<Country?> GetByName(string name);
        Task<Country?> GetByCapitalCity(string capitalCity);
        Task<Country?> GetRandomCountry(string continent);
        Task<IEnumerable<Country>> GetRandomCountries(string continents, int numberOfQuestions);
    }
}
