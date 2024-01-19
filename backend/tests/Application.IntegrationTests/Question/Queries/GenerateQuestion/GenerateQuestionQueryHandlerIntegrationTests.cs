using AutoMapper;
using Application.Common.Mappings;
using Application.Helper.Seeders.IntegrationTests;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Application.UnitTests.Helper;

namespace Application.Question.Queries.GenerateQuestion.IntegrationTests;

public class GenerateQuestionQueryHandlerIntegrationTests
{
    private readonly KeepLearningDbContextTest _dbContext;
    private readonly CountryService _countryServiceTest;
    private readonly IMapper _mapper;

    public GenerateQuestionQueryHandlerIntegrationTests()
    {
        var builder = new DbContextOptionsBuilder<KeepLearningDbContextTest>();
        builder.UseInMemoryDatabase("TestKeepLearningDb-GenerateQuestionQueryHandlerIntegrationTests");

        _dbContext = new KeepLearningDbContextTest(builder.Options);

        var continentSeederTest = new ContinentSeederTest(_dbContext);
        continentSeederTest.Seed();

        var countrySeederTest = new CountrySeederTest(_dbContext);
        countrySeederTest.Seed();

        _countryServiceTest = new CountryService(_dbContext);

        var mappingProfiles = new List<Profile>() {
            new CountryMappingProfile(),
            new ContinentMappingProfile()
            };

        var configuration = new MapperConfiguration(cfg =>
               cfg.AddProfiles(mappingProfiles));

        _mapper = configuration.CreateMapper();
    }

    public static IEnumerable<object[]> GetRandomQuestionQuerySamples()
    {
        var list = new List<GenerateQuestionQuery>()
        {
            new GenerateQuestionQuery()
            {
                Category = "Country",
                Continent = "Asia",
            },
            new GenerateQuestionQuery()
            {
                Category = "Capital City",
                Continent = "Asia",
            },
            new GenerateQuestionQuery()
            {
                Category = "Capital City",
                Continent = "Europe",
            },
            new GenerateQuestionQuery()
            {
                Category = "Country",
                Continent = "North America",
            }
        };

        return list.Select(el => new object[] { el });
    }

    [Theory()]
    [MemberData(nameof(GetRandomQuestionQuerySamples))]
    public async void Handle_WithCorrectData_ReturnQuestion(GenerateQuestionQuery generateQuestionQuery)
    {
        // arrange
        var generateQuestionQueryHandler = new GenerateQuestionQueryHandler(_dbContext, _countryServiceTest, _mapper);

        // act
        var result = await generateQuestionQueryHandler.Handle(generateQuestionQuery, CancellationToken.None);

        // assert
        result.Should().NotBeNull();
        result.QuestionText.Should().NotBeNullOrWhiteSpace();
        result.AnswerText.Should().NotBeNullOrWhiteSpace();
        result.QuestionNumber.Should().Be(1);
    }
}