using KeepLearning.Domain.Interfaces;
using KeepLearning.Infrastructure.Helper.Seeders.UnitTests;
using KeepLearning.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace KeepLearning.Infrastructure.Repositories.UnitTests
{
    public class CountryRepositoryTests
    {
        private readonly KeepLearningDbContext _dbContext;
        private readonly IContinentRepository _continentRepository;
        private readonly ICountryRepository _countryRepositoryTest;

        public CountryRepositoryTests()
        {
            var builder = new DbContextOptionsBuilder<KeepLearningDbContext>();
            builder.UseInMemoryDatabase("TestKeepLearningDb-CountryRepositoryTest");

            _dbContext = new KeepLearningDbContext(builder.Options);
            var continentSeederTest = new ContinentSeederTest(_dbContext);
            continentSeederTest.Seed();

            var countrySeederTest = new CountrySeederTest(_dbContext);
            countrySeederTest.Seed();

            _countryRepositoryTest = new CountryRepository(_dbContext);
            _continentRepository = new ContinentRepository(_dbContext);
        }

        [Fact()]
        public async void GetAll_ShouldReturnAllCountriesFromDatabase()
        {
            // arrange
            var numberOfAllCountries = 195;

            // act
            var allCountries = await _countryRepositoryTest.GetAll();

            // assert
            allCountries.Should().NotBeNull();
            allCountries.Count().Should().Be(numberOfAllCountries);
        }
    }
}