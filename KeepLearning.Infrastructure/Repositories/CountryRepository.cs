using KeepLearning.Application.Country;
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

        // TODO: Change to data without packing to Countries
        public async Task<Countries> GetAll()
        {
            var listOfCountry = await _dbContext.Countries
                        .ToListAsync();

            return new Countries(listOfCountry);
        }

        public async Task<Country?> GetByCapitalCity(string capitalCity)
            => await _dbContext.Countries.Where(c => c.CapitalCity == capitalCity).FirstOrDefaultAsync();

        // TODO: Change to data without packing to Countries
        public async Task<Countries> GetByContinent(string continent)
        {
            var listOfCountry = await _dbContext.Countries
                        .Where(c => c.Continent == continent)
                        .ToListAsync();

            return new Countries(listOfCountry);
        }

        // TODO: Change to data without packing to Countries
        public async Task<Countries> GetByContinents(IEnumerable<string> continents)
        {
            var listOfCountry = await _dbContext.Countries
                        .Where(c => continents.Contains(c.Continent))
                        .ToListAsync();

            return new Countries(listOfCountry);
        }

        public async Task<Country?> GetByName(string name)
            => await _dbContext.Countries.Where(c => c.Name == name).FirstOrDefaultAsync();
    }
}
