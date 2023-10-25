using KeepLearning.Application.Country;
using KeepLearning.Domain.Enteties;

namespace KeepLearning.Domain.Interfaces
{
    public interface ICountryRepository
    {
        Task<Countries> GetAll();
        Task<Countries> GetByContinent(string continent);
        Task<Countries> GetByContinents(IEnumerable<string> continents);
        Task<int> GetNumberOfCountries(IEnumerable<string> continents);
        Task<Country?> GetByName(string name);
        Task<Country?> GetByCapitalCity(string capitalCity);
    }
}
