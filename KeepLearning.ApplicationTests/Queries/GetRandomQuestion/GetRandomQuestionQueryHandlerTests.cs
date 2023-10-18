using KeepLearning.Application.Country;
using KeepLearning.Application.Models.Enums;
using KeepLearning.Domain.Interfaces;
using Moq;

namespace KeepLearning.Application.Queries.GetRandomQuestion.Tests
{
    public class GetRandomQuestionQueryHandlerTests
    {

        [Theory]
        [InlineData(GuessType.Value.Country, Continent.Name.Europe, "Warsaw")]
        [InlineData(GuessType.Value.CapitalCity, Continent.Name.Europe, "Poland")]
        public async void Handle_GetRandomQuestion_WhenGiveGuessTypeAndContinent(GuessType.Value guessType, Continent.Name continent, string questionText)
        {
            // arrange
            var poland = new Domain.Enteties.Country()
            {
                Name = "Poland",
                Abbreviation = "POL",
                CapitalCity = "Warsaw",
                Continent = "Europe"
            };

            var listOFCountry = new List<Domain.Enteties.Country>() { poland };

            var countries = new Countries(listOFCountry);

            var query = new GetRandomQuestionQuery()
            {
                GuessType = guessType,
                Continent = continent
            };

            var continentString = Continent.MapContinentToString(query.Continent);

            var countryRepositoryMock = new Mock<ICountryRepository>();
            countryRepositoryMock.Setup(country => country.GetByContinent(continentString)).ReturnsAsync(countries);

            var handler = new GetRandomQuestionQueryHandler(countryRepositoryMock.Object);

            // act
            var result = await handler.Handle(query, CancellationToken.None);

            // assert
            result.QuestionText.Should().Be(questionText);
        }
    }
}