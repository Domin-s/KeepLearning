using AutoMapper;
using KeepLearning.Domain.Enteties;
using KeepLearning.Domain.Interfaces;
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
                    Continent= "Europe"
                },
                new GetRandomQuestionQuery() {
                    Category=GuessType.Category.CapitalCity,
                    Continent= "Europe"
                },
            };

            return list.Select(q => new object[] { q });

        }

        [Theory]
        [MemberData(nameof(GetRandomQuestionData))]
        public async void Handle_GetRandomQuestion_WhenGiveGuessTypeAndContinent(GetRandomQuestionQuery getRandomQuestionQuery)
        {
            // arrange
            var continent = new Continent()
            {
                Id = Guid.NewGuid(),
                Name = getRandomQuestionQuery.Continent
            };

            var continentDto = new ContinentDto(getRandomQuestionQuery.Continent);

            var country = new Country()
            {
                Id = Guid.NewGuid(),
                Name = "Poland",
                Abbreviation = "POL",
                CapitalCity = "Warsaw",
                ContinentId = continent.Id,
                Continent = continent
            };

            var countryDto = new CountryDto()
            {
                Name = "Poland",
                Abbreviation = "POL",
                CapitalCity = "Warsaw",
                Continent = new ContinentDto(continentDto.Name)
            };

            var continentRepositoryMock = new Mock<IContinentRepository>();
            continentRepositoryMock.Setup(country => country.GetByName(continent.Name)).ReturnsAsync(continent);

            var countryRepositoryMock = new Mock<ICountryRepository>();
            countryRepositoryMock.Setup(country => country.GetRandom(continent.Id)).ReturnsAsync(country);

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<CountryDto>(country)).Returns(countryDto);

            var handler = new GetRandomQuestionQueryHandler(continentRepositoryMock.Object, countryRepositoryMock.Object, mapper.Object);

            var expectedResult = getRandomQuestionQuery.Category.Equals(GuessType.Category.Country) ? countryDto.Name : countryDto.CapitalCity;

            // act
            var result = await handler.Handle(getRandomQuestionQuery, CancellationToken.None);

            // assert
            result.QuestionText.Should().Be(expectedResult);
        }
    }
}