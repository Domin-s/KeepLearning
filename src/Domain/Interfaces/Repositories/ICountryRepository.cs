using Domain.Enteties;

namespace Domain.Interfaces
{
    public interface ICountryRepository
    {
        Task<Country?> GetByCapitalCity(string capitalCity);
        Task<Country?> GetByName(string name);
        Task<IEnumerable<Country>> GetAll();
        Task<IEnumerable<Country>> GetByContinents(IEnumerable<Guid> continentIds);
        Task<int> GetNumberOfCountries(IEnumerable<Guid> continentIds);
    }
}
