using KeepLearning.Application.Country;
using KeepLearning.Domain.Enteties;

namespace KeepLearning.Domain.Interfaces
{
    public interface ICountryRepository
    {
        Task<Countries> GetAll();
        Task<Countries> GetByContinent(string continent);
        Task<Countries> GetByContinents(IEnumerable<string> continents);
    }
}
