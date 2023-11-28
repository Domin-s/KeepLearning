using KeepLearning.Domain.Enteties;

namespace KeepLearning.Domain.Interfaces
{
    public interface ICountryRepository
    {
        Task<Country?> GetByCapitalCity(string capitalCity);
        Task<Country?> GetByName(string name);
        Task<Country?> GetRandom(Guid continentId);
        Task<IEnumerable<Country>> GetAll();
        Task<IEnumerable<Country>> GetByContinents(IEnumerable<Guid> continentIds);
        Task<IEnumerable<Country>> GetRandomCountries(IEnumerable<Guid> continentIds, int numberOfQuestions);
        Task<int> GetNumberOfCountries(IEnumerable<Guid> continentIds);
    }
}
