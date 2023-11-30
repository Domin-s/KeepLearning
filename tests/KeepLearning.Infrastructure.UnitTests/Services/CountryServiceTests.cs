using KeepLearning.Domain.Enteties;
using KeepLearning.Domain.Interfaces;
using Moq;
using static KeepLearning.Domain.Models.Enums.GuessType;

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