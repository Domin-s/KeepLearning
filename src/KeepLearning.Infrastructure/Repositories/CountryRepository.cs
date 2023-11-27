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
            => await GetCountry($"Exec GetCountryByCapitalCity @CapitalCity = \"{capitalCity}\";");

        public async Task<Country?> GetByName(string name)
            => await GetCountry($"Exec GetCountryByName @Name = \"{name}\";");

        public async Task<Country?> GetRandom(string continent)
            => await GetCountry($"Exec GetRandomCountry @Continent = \"{continent}\";");

        public async Task<IEnumerable<Country>> GetAll()
            => await GetCountries("Exec GetAllCountries;");

        public async Task<IEnumerable<Country>> GetByContinents(string continents)
            => await GetCountries($"Exec GetCountriesByContinents @Continents = \"{continents}\";");

        public async Task<IEnumerable<Country>> GetRandomCountries(string continents, int numberOfCountries)
            => await GetCountries($"Exec GetRandomCountries @Continents = \"{continents}\", @NumberOfCountries = \"{numberOfCountries}\";");

        public async Task<int> GetNumberOfCountries(string continents)
        {
            var countries = await GetCountries($"Exec GetCountriesByContinents @Continents = \"{continents}\";");

            return countries.Count();
        }

        private async Task<Country?> GetCountry(string sqlScript)
        {
            var result = await _dbContext.Countries.FromSqlRaw(sqlScript).ToListAsync();

            return result.First();
        }

        private async Task<List<Country>> GetCountries(string sqlScript)
        {
            var result = await _dbContext.Countries.FromSqlRaw(sqlScript).ToListAsync();

            return result;
        }
    }
}
