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
            => await _dbContext.Countries.FromSqlRaw("Exec GetAllCountries").ToListAsync();

        public async Task<Country?> GetByCapitalCity(string capitalCity)
            => await _dbContext.Countries.FromSqlRaw($"Exec GetCountryByCapitalCity @CapitalCity = {capitalCity}").FirstAsync();

        public async Task<List<Country>> GetByContinent(string continent)
            => await _dbContext.Countries.FromSqlRaw($"Exec GetCountryByContinent @Continent = {continent}").ToListAsync();

        public async Task<List<Country>> GetByContinents(IEnumerable<string> continents)
            => await _dbContext.Countries.FromSqlRaw($"Exec GetCountryByContinents @Continents = {continents.ToString}").ToListAsync();

        public async Task<Country?> GetByName(string name)
            => await _dbContext.Countries.FromSqlRaw($"Exec GetCountryByCapitalCity @Name = {name}").FirstAsync();

        public async Task<int> GetNumberOfCountries(string continents)
        {
            var countries = await _dbContext.Countries.FromSqlRaw($"Exec GetCountriesByContinents @Continents = '{continents}'").ToListAsync();
            return countries.Count;
        }

        public async Task<IEnumerable<Country>> GetRandomCountries(IEnumerable<string> continents, int numberOfQuestions)
            => await _dbContext.Countries.FromSqlRaw($"Exec GetRandomCountries @Continents = {continents} @NumberOfQuestion = {numberOfQuestions}").ToListAsync();

        public async Task<Country?> GetRandomCountry(IEnumerable<string> continents)
            => await _dbContext.Countries.FromSqlRaw($"Exec GetRandomCountry @Continents = {continents}").FirstAsync();
    }
}
