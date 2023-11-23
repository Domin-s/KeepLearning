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
            => await _dbContext.Countries.FromSqlRaw("Exec GetAllCountries;").ToListAsync();

        public async Task<Country?> GetByCapitalCity(string capitalCity)
            => await _dbContext.Countries.FromSqlRaw($"Exec GetCountryByCapitalCity @CapitalCity = {capitalCity};").FirstAsync();

        public async Task<List<Country>> GetByContinents(string continents)
            => await _dbContext.Countries.FromSqlRaw($"Exec GetCountriesByContinents @Continents = '{continents}';").ToListAsync();

        public async Task<Country?> GetByName(string name)
            => await _dbContext.Countries.FromSqlRaw($"Exec GetCountryByName @Name = {name};").FirstAsync();

        public async Task<int> GetNumberOfCountries(string continents)
        {
            var countries = await _dbContext.Countries.FromSqlRaw($"Exec GetCountriesByContinents @Continents = '{continents}';").ToListAsync();
            return countries.Count;
        }

        public async Task<IEnumerable<Country>> GetRandomCountries(string continents, int numberOfCountries)
            => await _dbContext.Countries.FromSqlRaw($"Exec GetRandomCountries @Continents = '{continents}', @NumberOfCountries = {numberOfCountries};").ToListAsync();

        public async Task<Country?> GetRandomCountry(string continent)
            => await _dbContext.Countries.FromSqlRaw($"Exec GetRandomCountries @Continents = '{continent}', @NumberOfCountries = 1;").FirstAsync();
    }
}
