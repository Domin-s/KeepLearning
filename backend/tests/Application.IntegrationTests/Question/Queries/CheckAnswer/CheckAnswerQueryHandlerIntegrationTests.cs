using Application.Helper.Seeders.IntegrationTests;
using Application.UnitTests.Helper;
using Ardalis.GuardClauses;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using static Domain.Models.Enums.GuessType;

namespace Application.Question.Queries.CheckAnswer.IntegrationTests;

public class CheckAnswerQueryHandlerIntegrationTests
{
    private readonly KeepLearningDbContextTest _dbContext;
    private readonly CountryService _countryService;

    public CheckAnswerQueryHandlerIntegrationTests()
    {
        var builder = new DbContextOptionsBuilder<KeepLearningDbContextTest>();
        builder.UseInMemoryDatabase("TestKeepLearningDb-CheckAnswerQueryHandlerIntegrationTests");

        _dbContext = new KeepLearningDbContextTest(builder.Options);

        var continentSeederTest = new ContinentSeederTest(_dbContext);
        continentSeederTest.Seed();

        var countrySeederTest = new CountrySeederTest(_dbContext);
        countrySeederTest.Seed();

        _countryService = new CountryService(_dbContext);
    }

    public static IEnumerable<object[]> GetCheckAnswerQueryWithCorrectAnswer()
    {
        var list = new List<CheckQuestionQuery>()
        {
            new CheckQuestionQuery()
            {
                Question = "La Paz",
                Answer = "Bolivia",
                Category = "Country"
            },
            new CheckQuestionQuery()
            {
                Question = "France",
                Answer = "Paris",
                Category = "Capital City"
            },
            new CheckQuestionQuery()
            {
                Question = "Warsaw",
                Answer = "PoLaND",
                Category = "Country"
            },
            new CheckQuestionQuery()
            {
                Question = "Nur-Sultan",
                Answer = "KAzAkhstAn",
                Category = "Country"
            },

        };

        return list.Select(el => new object[] { el });
    }

    [Theory()]
    [MemberData(nameof(GetCheckAnswerQueryWithCorrectAnswer))]
    public async void Handle_WithCorrectAnswer_ReturnTrue(CheckQuestionQuery checkQuestionQuery)
    {
        // arrange
        var checkQuestionQueryHandler = new CheckQuestionQueryHandler(_countryService);

        // act
        var result = await checkQuestionQueryHandler.Handle(checkQuestionQuery, CancellationToken.None);

        // assert
        result.Should().BeTrue();
    }

    public static IEnumerable<object[]> GetCheckAnswerQueryWithIncorrectAnswer()
    {
        var list = new List<CheckQuestionQuery>()
        {
            new CheckQuestionQuery()
            {
                Question = "La Paz",
                Answer = "Boliviaaa",
                Category = "Country"
            },
            new CheckQuestionQuery()
            {
                Question = "France",
                Answer = "",
                Category = "Capital City"
            },
            new CheckQuestionQuery()
            {
                Question = "Warsaw",
                Answer = "Krakow",
                Category = "Country"
            },
            new CheckQuestionQuery()
            {
                Question = "Nur-Sultan",
                Answer = "KazahstAN!!!!!!",
                Category = "Country"
            },

        };

        return list.Select(el => new object[] { el });
    }

    [Theory()]
    [MemberData(nameof(GetCheckAnswerQueryWithIncorrectAnswer))]
    public async void Handle_WithIncorrectAnswer_ReturnFalse(CheckQuestionQuery checkQuestionQuery)
    {
        // arrange
        var checkQuestionQueryHandler = new CheckQuestionQueryHandler(_countryService);

        // act
        var result = await checkQuestionQueryHandler.Handle(checkQuestionQuery, CancellationToken.None);

        // assert
        result.Should().BeFalse();

    }

    [Fact()]
    public void Handle_WithIncorrectAnswerAndFoCountryWhichDoesNotExist_ReturnExceptionNotFound()
    {
        // arrange
        var checkQuestionQuery = new CheckQuestionQuery()
        {
            Question = "NotExistCountry",
            Answer = "Warsaw",
            Category = "Country"
        };
        var checkQuestionQueryHandler = new CheckQuestionQueryHandler(_countryService);

        // act
        var action = () => checkQuestionQueryHandler.Handle(checkQuestionQuery, CancellationToken.None);

        // assert
        action.Invoking(action => action.Invoke())
            .Should().ThrowAsync<NotFoundException>();
    }
}