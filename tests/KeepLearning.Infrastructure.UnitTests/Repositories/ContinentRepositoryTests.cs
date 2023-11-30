using KeepLearning.Domain.Interfaces;
using KeepLearning.Infrastructure.Helper.Seeders.UnitTests;
using KeepLearning.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace KeepLearning.Infrastructure.Repositories.UnitTests
{
    public class ContinentRepositoryTests
    {

        private readonly KeepLearningDbContext _dbContext;
        private readonly IContinentRepository _continentRepository;

        public ContinentRepositoryTests()
        {
            var builder = new DbContextOptionsBuilder<KeepLearningDbContext>();
            builder.UseInMemoryDatabase("TestKeepLearningDb-ContinentRepositoryTests");

            _dbContext = new KeepLearningDbContext(builder.Options);
            var continentSeederTest = new ContinentSeederTest(_dbContext);
            continentSeederTest.Seed();

            _continentRepository = new ContinentRepository(_dbContext);
        }

        [Fact()]
        public async void GetAll_ShouldReturnAllContinentsFromDatabase()
        {
            // arrange
            var numberOfAllCountries = 6;

            // act
            var allCountries = await _continentRepository.GetAll();

            // assert
            allCountries.Should().NotBeNull();
            allCountries.Count().Should().Be(numberOfAllCountries);
        }
    }
}