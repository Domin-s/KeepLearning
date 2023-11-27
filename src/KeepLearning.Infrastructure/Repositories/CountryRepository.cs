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

        public async Task<Country?> GetByCapitalCity(string capitalCity)
            => await _dbContext.Countries.FirstAsync(country => country.CapitalCity == capitalCity);

        public async Task<Country?> GetByName(string name)
            => await _dbContext.Countries.FirstAsync(country => country.Name == name);

        public async Task<Country?> GetRandom(Continent continent)
        {
            var random = new Random();

            return await _dbContext.Countries
                    .Where(country => country.Continent == continent)
                    .OrderBy(country => random.Next())
                    .FirstAsync();
        }

        public async Task<IEnumerable<Country>> GetByContinents(IEnumerable<Continent> continents)
            => await _dbContext.Countries
                    .Where(country => continents.Contains(country.Continent))
                    .ToListAsync();


        public async Task<IEnumerable<Country>> GetAll()
            => await _dbContext.Countries.ToListAsync();

        public async Task<IEnumerable<Country>> GetRandomCountries(IEnumerable<Continent> continents, int numberOfQuestions)
        {
            var random = new Random();

            return await _dbContext.Countries
                    .Where(country => continents.Contains(country.Continent))
                    .OrderBy(country => random.Next())
                    .Take(numberOfQuestions)
                    .ToListAsync();
        }

        public async Task<int> GetNumberOfCountries(IEnumerable<Continent> continents)
            => await _dbContext.Countries.Where(country => continents.Contains(country.Continent)).CountAsync();
    }
}
