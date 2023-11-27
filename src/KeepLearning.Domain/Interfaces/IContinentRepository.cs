using KeepLearning.Domain.Enteties;

namespace KeepLearning.Domain.Interfaces
{
    public interface IContinentRepository
    {
        Task<Continent?> GetById(Guid id);
        Task<Continent?> GetByName(string name);
        Task<IEnumerable<Continent>> GetAll();
        Task<bool> Save(string name);
    }
}
