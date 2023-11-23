using KeepLearning.Domain.Interfaces;
using KeepLearning.Domain.Models;
using KeepLearning.Domain.Models.Enums;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;

namespace KeepLearning.Domain.Queries.GetRandomQuestion.Tests
{
    public class GetRandomQuestionQueryHandlerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        [Theory]
        [InlineData(GuessType.Category.Country, Continent.Name.Europe, "Warsaw")]
        [InlineData(GuessType.Category.CapitalCity, Continent.Name.Europe, "Poland")]
        public async void Handle_GetRandomQuestion_WhenGiveGuessTypeAndContinent(GuessType.Category category, Continent.Name continent, string questionText)
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
                Category = category,
                Continent = continent
            };

            var continents = new List<Continent.Name>() { continent };

            var continentString = Continent.MapContinentToString(query.Continent);

            var countryRepositoryMock = new Mock<ICountryRepository>();
            countryRepositoryMock.Setup(country => country.GetRandomCountry(continentString)).ReturnsAsync(poland);

            var handler = new GetRandomQuestionQueryHandler(countryRepositoryMock.Object);

            // act
            var result = await handler.Handle(query, CancellationToken.None);

            // assert
            result.QuestionText.Should().Be(questionText);
        }
    }
}