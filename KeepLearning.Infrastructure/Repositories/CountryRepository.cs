using KeepLearning.Domain.Enteties;
using KeepLearning.Domain.Interfaces;
using KeepLearning.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace KeepLearning.Infrastructure.Repositories
{
    internal class CountryRepository : ICountryRepository
    {
        private readonly KeepLearningDbContext _dbContext;

        public CountryRepository(KeepLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Country>> GetAll()
            => await _dbContext.Countries.ToListAsync();

        public async Task<Country?> GetByCapitalCity(string capitalCity)
            => await _dbContext.Countries.Where(c => c.CapitalCity == capitalCity).FirstOrDefaultAsync();

        public async Task<List<Country>> GetByContinent(string continent)
            => await _dbContext.Countries
                        .Where(c => c.Continent == continent)
                        .ToListAsync();
        
        public async Task<List<Country>> GetByContinents(IEnumerable<string> continents)
            => await _dbContext.Countries
                        .Where(c => continents.Contains(c.Continent))
                        .ToListAsync();

        public async Task<Country?> GetByName(string name)
            => await _dbContext.Countries.Where(c => c.Name == name).FirstOrDefaultAsync();

        public async Task<int> GetNumberOfCountries(IEnumerable<string> continents)
            => await _dbContext.Countries
                        .Where(c => continents.Contains(c.Continent))
                        .CountAsync();
    }
}
