using KeepLearning.Domain.Enteties;
using KeepLearning.Domain.Interfaces;
using KeepLearning.Infrastructure.Repositories.UnitTests;
using KeepLearning.Infrastructure.Repositories;
using Moq;
using static KeepLearning.Domain.Models.Enums.GuessType;
using System.Diagnostics.Metrics;
using static KeepLearning.Infrastructure.Repositories.UnitTests.CountryRepositoryTests;
using KeepLearning.Domain.Models;

namespace KeepLearning.Infrastructure.Services.UnitTests
{
    public class CountryServiceTests
    {
        public record CountryAndCategory(Country country, Category category) { }

        public static IEnumerable<object[]> GetQuestionCategoryAndAnswer()
        {
            var list = new List<CountryAndCategory>()
            {
                new CountryAndCategory(new Country() {
                    Name = "Bolivia",
                    Abbreviation = "BOL",
                    CapitalCity = "La Paz",
                    ContinentId = Guid.NewGuid()
                }, Category.CapitalCity),

                new CountryAndCategory(new Country() {
                    Name = "Poland",
                    Abbreviation = "POL",
                    CapitalCity = "Warsaw",
                    ContinentId = Guid.NewGuid()
                }, Category.Country),

                new CountryAndCategory(new Country() {
                    Name = "Germany",
                    Abbreviation = "GER",
                    CapitalCity = "Berlin",
                    ContinentId = Guid.NewGuid()
                }, Category.CapitalCity),

                new CountryAndCategory(new Country() {
                    Name = "Australia",
                    Abbreviation = "AUS",
                    CapitalCity = "Canberra",
                    ContinentId = Guid.NewGuid()
                }, Category.Country)
            };

            return list.Select(el => new[] { el });
        }

        [Theory]
        [MemberData(nameof(GetQuestionCategoryAndAnswer))]
        public async Task GetCorrectAnswer_WithValidCountry_ReturnCorrectAnswer(CountryAndCategory countryAndCategory)
        {
            // arrange
            var guessTypeCategory = countryAndCategory.category;
            var questionText = GetQuestionText(countryAndCategory.country, guessTypeCategory);
            var answerText = GetAnswerText(countryAndCategory.country, guessTypeCategory);

            var countryRepositoryMock = new Mock<ICountryRepository>();
            countryRepositoryMock.Setup(rep => rep.GetByName(countryAndCategory.country.Name)).ReturnsAsync(countryAndCategory.country);
            countryRepositoryMock.Setup(rep => rep.GetByCapitalCity(countryAndCategory.country.CapitalCity)).ReturnsAsync(countryAndCategory.country);

            var countryService = new CountryService(countryRepositoryMock.Object);

            // act
            var result = await countryService.GetCorrectAnswer(questionText, guessTypeCategory);

            // assert
            result.Should().Be(answerText);
        }

        [Theory]
        [MemberData(nameof(GetQuestionCategoryAndAnswer))]
        public async Task IsCorrectAnswer_WithValidCountry_ReturnTrue(CountryAndCategory countryAndCategory)
        {
            // arrange
            var guessTypeCategory = countryAndCategory.category;
            var questionText = GetQuestionText(countryAndCategory.country, guessTypeCategory);
            var answerText = GetAnswerText(countryAndCategory.country, guessTypeCategory);

            var countryRepositoryMock = new Mock<ICountryRepository>();
            countryRepositoryMock.Setup(rep => rep.GetByName(countryAndCategory.country.Name)).ReturnsAsync(countryAndCategory.country);
            countryRepositoryMock.Setup(rep => rep.GetByCapitalCity(countryAndCategory.country.CapitalCity)).ReturnsAsync(countryAndCategory.country);

            var countryService = new CountryService(countryRepositoryMock.Object);

            // act
            var result = await countryService.IsCorrectAnswer(questionText, answerText, guessTypeCategory);

            // assert
            result.Should().Be(true);
        }

        [Fact]
        public async Task IsCorrectAnswer_WithWrongAnswer_ReturnFalse()
        {
            // arrange
            var country = new Country()
            {
                Name = "Australia",
                Abbreviation = "AUS",
                CapitalCity = "Canberra",
                ContinentId = Guid.NewGuid()
            };

            var guessTypeCategory = Category.Country;

            var questionText = GetQuestionText(country, guessTypeCategory);
            var wrongAnswerText = "Wrong answer";

            var countryRepositoryMock = new Mock<ICountryRepository>();
            countryRepositoryMock.Setup(rep => rep.GetByName(country.Name)).ReturnsAsync(country);
            countryRepositoryMock.Setup(rep => rep.GetByCapitalCity(country.CapitalCity)).ReturnsAsync(country);

            var countryService = new CountryService(countryRepositoryMock.Object);

            // act
            var result = await countryService.IsCorrectAnswer(questionText, wrongAnswerText, guessTypeCategory);

            // assert
            result.Should().Be(false);
        }

        [Fact()]
        public async void GetRandomCountry_ForValidContinent_ReturnRadnomCountryWithGivenContinent()
        {
            // arrange
            var continentIds = new List<Guid>() { Guid.NewGuid() };
            var continentId = continentIds.First();

            var countries = new List<Country>() {
                new Country()
                {
                    Name = "Australia",
                    Abbreviation = "AUS",
                    CapitalCity = "Canberra",
                    ContinentId = continentId
                }
            };

            var countryRepositoryMock = new Mock<ICountryRepository>();
            countryRepositoryMock.Setup(rep => rep.GetByContinents(continentIds)).ReturnsAsync(countries);

            var countryService = new CountryService(countryRepositoryMock.Object);


            // act
            var randomCountry = await countryService.GetRandom(continentId);

            // assert
            randomCountry.Should().NotBeNull();
            randomCountry!.ContinentId.Should().Be(continentId);
        }

        [Theory()]
        [InlineData(1)]
        [InlineData(2)]
        public async void GetRandomCountries_ForValidContinent_ReturnRadnomCountriesWithoutDuplicate(int numberOfElemetns)
        {
            // arrange
            var continentIds = new List<Guid>() { Guid.NewGuid() };
            var continentId = continentIds.First();

            var countries = new List<Country>() {
                new Country()
                {
                    Name = "Croatia",
                    Abbreviation = "HRV",
                    CapitalCity = "Zagreb",
                    ContinentId = continentId
                },
                new Country()
                {
                    Name = "Greece",
                    Abbreviation = "GRC",
                    CapitalCity = "Athens",
                    ContinentId = continentId
                },
            };

            var countryRepositoryMock = new Mock<ICountryRepository>();
            countryRepositoryMock.Setup(rep => rep.GetByContinents(continentIds)).ReturnsAsync(countries);

            var countryService = new CountryService(countryRepositoryMock.Object);

            // act
            var randomCountries = await countryService.RandomCountries(continentIds, numberOfElemetns);

            // assert
            randomCountries.Should().NotBeNull();
            randomCountries.Count().Should().Be(numberOfElemetns);
            randomCountries.Distinct().Count().Should().Be(numberOfElemetns);
        }

        private string GetQuestionText(Country country, Category categry)
        {
            switch (categry)
            {
                case Category.Country: return country.CapitalCity;
                case Category.CapitalCity: return country.Name;
                default: throw new NotImplementedException();
            }
        }

        private string GetAnswerText(Country country, Category categry)
        {
            switch (categry)
            {
                case Category.Country: return country.Name;
                case Category.CapitalCity: return country.CapitalCity;
                default: throw new NotImplementedException();
            }
        }
    }
}