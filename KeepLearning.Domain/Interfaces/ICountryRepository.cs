using KeepLearning.Application.Country;
using KeepLearning.Domain.Enteties;

namespace KeepLearning.Domain.Interfaces
{
    public interface ICountryRepository
    {
        Task<Countries> GetAll();
        // TODO: Check if I can put object
        Task<Countries> GetByContinent(string continent);
        Task<Countries> GetByContinents(IEnumerable<string> continents);
        Task<Country?> GetByName(string name);
        Task<Country?> GetByCapitalCity(string capitalCity);
    }
}
