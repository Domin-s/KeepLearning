using KeepLearning.Domain.Enteties;

namespace KeepLearning.Domain.Interfaces
{
    public interface IContinentRepository
    {
        Task<IEnumerable<Continent>> GetAll();
        Task<Continent?> GetById(Guid id);
        Task<Continent?> GetByName(string name);
        Task<IEnumerable<Continent>> GetByNames(IEnumerable<string> names);
    }
}
