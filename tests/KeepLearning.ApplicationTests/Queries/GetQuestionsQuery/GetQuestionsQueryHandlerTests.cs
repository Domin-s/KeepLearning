using KeepLearning.ApplicationTests.Helper.Country;
using KeepLearning.Domain.Interfaces;
using KeepLearning.Domain.Models.Enums;
using Moq;

namespace KeepLearning.Domain.Queries.CreateTestCountry.Tests
{
    public class GetQuestionsQueryHandlerTests
    {
        private readonly IEnumerable<Domain.Enteties.Country> countries = CountryData.GetCountries();

        public static IEnumerable<object[]> GetDataForQuery()
        {
            var queries = new List<CreateTestCountryQuery>()
            {
                new CreateTestCountryQuery()
                {
                    Name = "First test",
                    NumberOfQuestion = 5,
                    Category = GuessType.Category.Country,
                    Continents = new List<Continent.Name>(){ Continent.Name.Asia }
                },
                new CreateTestCountryQuery()
                {
                    Name = "Second test",
                    NumberOfQuestion = 10,
                    Category = GuessType.Category.Country,
                    Continents = new List<Continent.Name>(){ Continent.Name.Asia }
                },
                new CreateTestCountryQuery()
                {
                    Name = "Third test",
                    NumberOfQuestion = 15,
                    Category = GuessType.Category.Country,
                    Continents = new List<Continent.Name>(){ Continent.Name.Asia }
                }
            };

            return queries.Select(q => new object[] { q });
        }

        [Theory]
        [MemberData(nameof(GetDataForQuery))]
        public async void Handle_GetRandomQuestions_WhenNumberOfQuestionIsLowerThanCountriesFromContinent(CreateTestCountryQuery getQuestionsQuery)
        {
            // arrange
            var continentsString = getQuestionsQuery.Continents.Select(c => Continent.MapContinentToString(c));

            var listOfCountry = GetCountries(continentsString);

            var countryServiceMock = new Mock<ICountryService>();
            countryServiceMock.Setup(country => country.GetRandomCountries(getQuestionsQuery.Continents, getQuestionsQuery.NumberOfQuestion)).ReturnsAsync(listOfCountry);

            var handler = new CreateTestCountryQueryHandler(countryServiceMock.Object);

            // act
            var result = await handler.Handle(getQuestionsQuery, CancellationToken.None);

            // assert
            result.Name.Should().Be(getQuestionsQuery.Name);
            result.NumberOfQuestion.Should().Be(getQuestionsQuery.NumberOfQuestion);
            result.Category.Should().Be(getQuestionsQuery.Category);
            result.Continents.Should().Contain(getQuestionsQuery.Continents);
        }

        private IEnumerable<Domain.Enteties.Country> GetCountries(IEnumerable<string> continents)
             => countries.Where(c => continents.Contains(c.Continent));
    }
}