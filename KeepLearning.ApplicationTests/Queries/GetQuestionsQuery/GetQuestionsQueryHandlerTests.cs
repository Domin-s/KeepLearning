using KeepLearning.ApplicationTests.Helper.Country;
using KeepLearning.Domain.Interfaces;
using KeepLearning.Domain.Models;
using KeepLearning.Domain.Models.Enums;
using Moq;

namespace KeepLearning.Domain.Queries.GetQuestions.Tests
{
    public class GetQuestionsQueryHandlerTests
    {
        private readonly IEnumerable<Domain.Enteties.Country> countries = CountryData.GetCountries();

        public static IEnumerable<object[]> GetDataForQuery()
        {
            var queries = new List<GetQuestionsQuery>()
            {
                new GetQuestionsQuery()
                {
                    Name = "First test",
                    NumberOfQuestion = 5,
                    GuessType = GuessType.Value.Country,
                    Continents = new List<Continent.Name>(){ Continent.Name.Asia }
                },
                new GetQuestionsQuery()
                {
                    Name = "Second test",
                    NumberOfQuestion = 10,
                    GuessType = GuessType.Value.Country,
                    Continents = new List<Continent.Name>(){ Continent.Name.Asia }
                },
                new GetQuestionsQuery()
                {
                    Name = "Third test",
                    NumberOfQuestion = 15,
                    GuessType = GuessType.Value.Country,
                    Continents = new List<Continent.Name>(){ Continent.Name.Asia }
                }
            };

            return queries.Select(q => new object[] { q });
        }

        [Theory]
        [MemberData(nameof(GetDataForQuery))]
        public async void Handle_GetRandomQuestions_WhenNumberOfQuestionIsLowerThanCountriesFromContinent(GetQuestionsQuery getQuestionsQuery)
        {
            // arrange
            var continentsString = getQuestionsQuery.Continents.Select(c => Continent.MapContinentToString(c));

            var listOfCountry = GetCountries(continentsString);

            var countries = new Countries(listOfCountry) { };

            var countryRepositoryMock = new Mock<ICountryRepository>();
            countryRepositoryMock.Setup(country => country.GetByContinents(continentsString)).ReturnsAsync(countries);

            var countryServiceMock = new Mock<ICountryService>();
            countryServiceMock.Setup(country => country.GetRandomCountries(getQuestionsQuery.NumberOfQuestion)).Returns(listOfCountry);

            var handler = new GetQuestionsQueryHandler(countryRepositoryMock.Object, countryServiceMock.Object);

            // act
            var result = await handler.Handle(getQuestionsQuery, CancellationToken.None);

            // assert
            result.Name.Should().Be(getQuestionsQuery.Name);
            result.NumberOfQuestion.Should().Be(getQuestionsQuery.NumberOfQuestion);
            result.GuessType.Should().Be(getQuestionsQuery.GuessType);
            result.Continents.Should().Contain(getQuestionsQuery.Continents);
        }

        private IEnumerable<Domain.Enteties.Country> GetCountries(IEnumerable<string> continents)
             => countries.Where(c => continents.Contains(c.Continent));
    }
}