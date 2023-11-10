using KeepLearning.Domain.Enteties;

namespace KeepLearning.Domain.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAll();
        Task<List<Country>> GetByContinent(string continent);
        Task<List<Country>> GetByContinents(IEnumerable<string> continents);
        Task<int> GetNumberOfCountries(IEnumerable<string> continents);
        Task<Country?> GetByName(string name);
        Task<Country?> GetByCapitalCity(string capitalCity);
    }
}
