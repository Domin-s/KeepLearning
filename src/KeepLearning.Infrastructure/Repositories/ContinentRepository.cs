using KeepLearning.Domain.Enteties;
using KeepLearning.Domain.Interfaces;
using KeepLearning.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace KeepLearning.Infrastructure.Repositories
{
    public class ContinentRepository : IContinentRepository
    {
        private readonly KeepLearningDbContext _dbContext;

        public ContinentRepository(KeepLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Continent>> GetAll()
            => await _dbContext.Continents.FromSqlRaw("Exec GetAllContinents;").ToListAsync<Continent>();

        public async Task<Continent?> GetById(Guid id)
            => await GetContient($"Exec GetContinentById @Id = \"{id}\";");

        public async Task<Continent?> GetByName(string name)
            => await GetContient($"Exec GetContinentByName @Id = \"{name}\";");

        public async Task<bool> Save(string name)
            => await _dbContext.Continents.FromSqlRaw($"Exec SaveContinent @Id = {Guid.NewGuid}, @Name = {name}").AnyAsync();

        private async Task<Continent?> GetContient(string sqlScript)
        {
            var result = await _dbContext.Continents.FromSqlRaw(sqlScript).ToListAsync<Continent>();

            return result.First();
        }
    }

}