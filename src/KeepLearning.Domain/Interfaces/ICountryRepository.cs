using KeepLearning.Domain.Enteties;

namespace KeepLearning.Domain.Interfaces
{
    public interface ICountryRepository
    {
        Task<Country?> GetByCapitalCity(string capitalCity);
        Task<Country?> GetByName(string name);
        Task<Country?> GetRandom(string continent);
        Task<IEnumerable<Country>> GetAll();
        Task<IEnumerable<Country>> GetByContinents(string continents);
        Task<IEnumerable<Country>> GetRandomCountries(string continents, int numberOfQuestions);
        Task<int> GetNumberOfCountries(string continents);
        Task<bool> Save(string name, string abbreviation, string capitalCity, string continent);
    }
}
