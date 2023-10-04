using KeepLearning.Domain.Enteties;

namespace KeepLearning.Domain.Interfaces
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAll();
        Task<IEnumerable<Country>> GetByContinents(IEnumerable<string> continents);
    }
}
