using KeepLearning.ApplicationTests.Helper.Country;
using KeepLearning.Domain.Commands.CreateTestCountry;
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
            var queries = new List<CreateTestCountryCommand>()
            {
                new CreateTestCountryCommand()
                {
                    Name = "First test",
                    NumberOfQuestion = 5,
                    Category = GuessType.Category.Country,
                    Continents = new List<Continent.Name>(){ Continent.Name.Asia }
                },
                new CreateTestCountryCommand()
                {
                    Name = "Second test",
                    NumberOfQuestion = 10,
                    Category = GuessType.Category.Country,
                    Continents = new List<Continent.Name>(){ Continent.Name.Asia }
                },
                new CreateTestCountryCommand()
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
        public async void Handle_GetRandomQuestions_WhenNumberOfQuestionIsLowerThanCountriesFromContinent(CreateTestCountryCommand createTestCountryCommand)
        {
            // arrange
            var continentsOneString = string.Join(",", createTestCountryCommand.Continents);
            var listOfContinents = createTestCountryCommand.Continents.Select(c => Continent.MapContinentToString(c));

            var listOfCountry = GetCountries(listOfContinents);

            var countryRepositoryMock = new Mock<ICountryRepository>();
            countryRepositoryMock.Setup(cr => cr.GetRandomCountries(continentsOneString, createTestCountryCommand.NumberOfQuestion)).ReturnsAsync(listOfCountry);

            var handler = new CreateTestCountryCommandHandler(countryRepositoryMock.Object);

            // act
            var result = await handler.Handle(createTestCountryCommand, CancellationToken.None);

            // assert
            result.Name.Should().Be(createTestCountryCommand.Name);
            result.NumberOfQuestion.Should().Be(createTestCountryCommand.NumberOfQuestion);
            result.Category.Should().Be(createTestCountryCommand.Category);
            result.Continents.Should().Contain(createTestCountryCommand.Continents);
        }

        private IEnumerable<Domain.Enteties.Country> GetCountries(IEnumerable<string> continents)
             => countries.Where(c => continents.Contains(c.Continent));
    }
}