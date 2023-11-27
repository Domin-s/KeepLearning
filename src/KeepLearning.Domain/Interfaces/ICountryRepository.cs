using KeepLearning.Domain.Enteties;

namespace KeepLearning.Domain.Interfaces
{
    public interface ICountryRepository
    {
        Task<Country?> GetByCapitalCity(string capitalCity);
        Task<Country?> GetByName(string name);
        Task<Country?> GetRandom(Continent continent);
        Task<IEnumerable<Country>> GetAll();
        Task<IEnumerable<Country>> GetByContinents(IEnumerable<Continent> continents);
        Task<IEnumerable<Country>> GetRandomCountries(IEnumerable<Continent> continents, int numberOfQuestions);
        Task<int> GetNumberOfCountries(IEnumerable<Continent> continents);
    }
}
