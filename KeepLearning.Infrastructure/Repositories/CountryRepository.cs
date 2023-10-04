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

        public async Task<IEnumerable<Country>> GetAll()
            => await _dbContext.Countries
                        .ToListAsync();

        public async Task<IEnumerable<Country>> GetByContinent(IEnumerable<string> continents)
            => await _dbContext.Countries
                        .Where(c => continents.Contains(c.Continent))
                        .ToListAsync();
    }
}
