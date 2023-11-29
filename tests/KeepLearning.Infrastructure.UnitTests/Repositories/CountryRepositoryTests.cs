using KeepLearning.Domain.Interfaces;
using KeepLearning.Infrastructure.Persistence;
using KeepLearning.Infrastructure.Repositories;
using KeepLearning.Infrastructure.UnitTests.Helper.Seeders;
using Microsoft.EntityFrameworkCore;

namespace KeepLearning.Infrastructure.UnitTests.Repositories
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

        [Theory()]
        [InlineData("Asia")]
        [InlineData("Europe")]
        [InlineData("N. America")]
        public async void GetRandomCountry_ForValidContinent_ReturnRadnomCountryWithGivenContinent(string continentName)
        {
            // arrange
            var continent = await _continentRepository.GetByName(continentName);

            // act
            var randomCountry = await _countryRepositoryTest.GetRandom(continent!.Id);

            // assert
            randomCountry.Should().NotBeNull();
            randomCountry!.ContinentId.Should().Be(continent!.Id);
        }

        public record ContinentsWithNumberOfCountries(IEnumerable<string> continentNames, int numberOfCountries) { }

        public static IEnumerable<object[]> GetListOfContinentsWithNumberOfCountries()
        {
            var list = new List<ContinentsWithNumberOfCountries>()
            {
                new ContinentsWithNumberOfCountries(new List<string>() { "Asia" }, 5),
                new ContinentsWithNumberOfCountries(new List<string>() { "Asia", "Europe" }, 10),
                new ContinentsWithNumberOfCountries(new List<string>() { "Asia", "Africa" }, 20),
                new ContinentsWithNumberOfCountries(new List<string>() { "Africa", "Europe" }, 25),
                new ContinentsWithNumberOfCountries(new List<string>() { "Asia", "Africa", "Europe" }, 50),
            };

            return list.Select(el => new object[] { el });
        }

        [Theory()]
        [MemberData(nameof(GetListOfContinentsWithNumberOfCountries))]
        public async void GetRandomCountries_ForValidContinent_ReturnRadnomCountriesWithoutDuplicate(ContinentsWithNumberOfCountries element)
        {
            // arrange
            var continents = await _continentRepository.GetByNames(element.continentNames);
            var ids = continents.Select(c => c.Id);

            // act
            var randomCountries = await _countryRepositoryTest.GetRandomCountries(ids, element.numberOfCountries);

            // assert
            randomCountries.Should().NotBeNull();
            randomCountries.Count().Should().Be(element.numberOfCountries);
            randomCountries.Distinct().Count().Should().Be(element.numberOfCountries);
        }
    }
}