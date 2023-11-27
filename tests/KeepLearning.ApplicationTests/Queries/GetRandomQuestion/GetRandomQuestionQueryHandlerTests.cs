using AutoMapper;
using KeepLearning.Domain.Enteties;
using KeepLearning.Domain.Interfaces;
using KeepLearning.Domain.Models;
using KeepLearning.Domain.Models.Continent;
using KeepLearning.Domain.Models.Country;
using KeepLearning.Domain.Models.Enums;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;

namespace KeepLearning.Domain.Queries.GetRandomQuestion.Tests
{
    public class GetRandomQuestionQueryHandlerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        public static IEnumerable<object[]> GetRandomQuestionData()
        {

            var list = new List<GetRandomQuestionQuery>(){
                new GetRandomQuestionQuery() {
                    Category=GuessType.Category.Country,
                    Continent= new Continent(){
                        Id = Guid.NewGuid(),
                        Name = "Europe"
                    }
                },
                new GetRandomQuestionQuery() {
                    Category=GuessType.Category.CapitalCity,
                    Continent= new Continent(){
                        Id = Guid.NewGuid(),
                        Name = "Europe"
                    }
                },
            };

            return list.Select(q => new object[] { q });

        }

        // [InlineData(GuessType.Category.Country, Continent, "Warsaw")]
        // [InlineData(GuessType.Category.CapitalCity, Continent, "Poland")]

        [Theory]
        [MemberData(nameof(GetRandomQuestionData))]
        public async void Handle_GetRandomQuestion_WhenGiveGuessTypeAndContinent(GetRandomQuestionQuery getRandomQuestionQuery)
        {
            // arrange
            var continent = getRandomQuestionQuery.Continent;

            var poland = new Country()
            {
                Id = Guid.NewGuid(),
                Name = "Poland",
                Abbreviation = "POL",
                CapitalCity = "Warsaw",
                ContinentId = continent.Id,
                Continent = continent
            };

            var polandDto = new CountryDto()
            {
                Name = "Poland",
                CapitalCity = "Warsaw",
                Continent = new ContinentDto(continent.Name)
            };

            var countryRepositoryMock = new Mock<ICountryRepository>();
            countryRepositoryMock.Setup(country => country.GetRandom(getRandomQuestionQuery.Continent.Name)).ReturnsAsync(poland);

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<CountryDto>(poland)).Returns(polandDto);

            var handler = new GetRandomQuestionQueryHandler(countryRepositoryMock.Object, mapper.Object);

            var expectedResult = getRandomQuestionQuery.Category.Equals(GuessType.Category.Country) ? polandDto.Name : polandDto.CapitalCity;

            // act
            var result = await handler.Handle(getRandomQuestionQuery, CancellationToken.None);

            // assert
            result.QuestionText.Should().Be(expectedResult);
        }
    }
}