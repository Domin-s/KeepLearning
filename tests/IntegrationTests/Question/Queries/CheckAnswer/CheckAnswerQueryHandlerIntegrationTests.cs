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
        var list = new List<CheckAnswerQuery>()
        {
            new CheckAnswerQuery()
            {
                Question = "La Paz",
                Answer = "Bolivia",
                Category = Category.Country
            },
            new CheckAnswerQuery()
            {
                Question = "France",
                Answer = "Paris",
                Category = Category.CapitalCity
            },
            new CheckAnswerQuery()
            {
                Question = "Warsaw",
                Answer = "PoLaND",
                Category = Category.Country
            },
            new CheckAnswerQuery()
            {
                Question = "Nur-Sultan",
                Answer = "KAzAkhstAn",
                Category = Category.Country
            },

        };

        return list.Select( el => new object[] { el });
    }

    [Theory()]
    [MemberData(nameof(GetCheckAnswerQueryWithCorrectAnswer))]
    public async void Handle_WithCorrectAnswer_ReturnTrue(CheckAnswerQuery checkAnswerQuery)
    {
        // arrange
        var checkAnswerQueryHandler = new CheckAnswerQueryHandler(_countryService);

        // act
        var result = await checkAnswerQueryHandler.Handle(checkAnswerQuery, CancellationToken.None);

        // assert
        result.Should().BeTrue();
    }

    public static IEnumerable<object[]> GetCheckAnswerQueryWithIncorrectAnswer()
    {
        var list = new List<CheckAnswerQuery>()
        {
            new CheckAnswerQuery()
            {
                Question = "La Paz",
                Answer = "Boliviaaa",
                Category = Category.Country
            },
            new CheckAnswerQuery()
            {
                Question = "France",
                Answer = "",
                Category = Category.CapitalCity
            },
            new CheckAnswerQuery()
            {
                Question = "Warsaw",
                Answer = "Krakow",
                Category = Category.Country
            },
            new CheckAnswerQuery()
            {
                Question = "Nur-Sultan",
                Answer = "KazahstAN!!!!!!",
                Category = Category.Country
            },

        };

        return list.Select(el => new object[] { el });
    }

    [Theory()]
    [MemberData(nameof(GetCheckAnswerQueryWithIncorrectAnswer))]
    public async void Handle_WithIncorrectAnswer_ReturnFalse(CheckAnswerQuery checkAnswerQuery)
    {
        // arrange
        var checkAnswerQueryHandler = new CheckAnswerQueryHandler(_countryService);

        // act
        var result = await checkAnswerQueryHandler.Handle(checkAnswerQuery, CancellationToken.None);

        // assert
        result.Should().BeFalse();

    }

    [Fact()]
    public void Handle_WithIncorrectAnswerAndFoCountryWhichDoesNotExist_ReturnExceptionNotFound()
    {
        // arrange
        var checkAnswerQuery = new CheckAnswerQuery()
        {
            Question = "NotExistCountry",
            Answer = "Warsaw",
            Category = Category.Country
        };
        var checkAnswerQueryHandler = new CheckAnswerQueryHandler(_countryService);

        // act
        var action = () => checkAnswerQueryHandler.Handle(checkAnswerQuery, CancellationToken.None);

        // assert
        action.Invoking(action => action.Invoke())
            .Should().ThrowAsync<NotFoundException>();
    }
}