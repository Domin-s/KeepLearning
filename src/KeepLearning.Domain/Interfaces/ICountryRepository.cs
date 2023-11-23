using KeepLearning.Domain.Enteties;

namespace KeepLearning.Domain.Interfaces
{
    public interface ICountryRepository
    {
        Task<Country?> GetByCapitalCity(string capitalCity);
        Task<Country?> GetByName(string name);
        Task<Country?> GetRandom(string continent);
        Task<List<Country>> GetAll();
        Task<List<Country>> GetByContinents(string continents);
        Task<List<Country>> GetRandomCountries(string continents, int numberOfQuestions);
        Task<int> GetNumberOfCountries(string continents);
    }
}
