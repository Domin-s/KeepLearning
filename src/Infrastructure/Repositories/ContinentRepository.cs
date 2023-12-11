using Domain.Enteties;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class ContinentRepository : IContinentRepository
    {
        private readonly KeepLearningDbContext _dbContext;

        public ContinentRepository(KeepLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Continent>> GetAll()
            => await _dbContext.Continents.ToListAsync();

        public async Task<Continent?> GetById(Guid id)
            => await _dbContext.Continents.Where(c => c.Id == id).FirstAsync();

        public async Task<Continent?> GetByName(string name)
            => await _dbContext.Continents.Where(c => c.Name == name).FirstAsync();

        public async Task<IEnumerable<Continent>> GetByNames(IEnumerable<string> names)
            => await _dbContext.Continents.Where(c => names.Contains(c.Name)).ToListAsync();
    }
}