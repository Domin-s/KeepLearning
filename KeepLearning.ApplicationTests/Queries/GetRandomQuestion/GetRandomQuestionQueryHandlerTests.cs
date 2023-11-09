using KeepLearning.Domain.Interfaces;
using KeepLearning.Domain.Models;
using KeepLearning.Domain.Models.Enums;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;

namespace KeepLearning.Domain.Queries.GetRandomQuestion.Tests
{
    public class GetRandomQuestionQueryHandlerTests: IClassFixture<WebApplicationFactory<Program>>
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

            var countryServiceMock = new Mock<ICountryService>();
            countryServiceMock.Setup(country => country.GetRandomCountry(listOFCountry)).Returns(poland);

            var handler = new GetRandomQuestionQueryHandler(countryRepositoryMock.Object, countryServiceMock.Object);

            // act
            var result = await handler.Handle(query, CancellationToken.None);

            // assert
            result.QuestionText.Should().Be(questionText);
        }
    }
}