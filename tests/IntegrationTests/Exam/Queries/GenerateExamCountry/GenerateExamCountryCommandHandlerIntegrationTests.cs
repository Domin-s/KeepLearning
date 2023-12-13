using Application.Common.Mappings;
using Application.Exam.Queries.GenerateExamCountry;
using Application.Helper.Seeders.IntegrationTests;
using Application.UnitTests.Helper;
using Ardalis.GuardClauses;
using AutoMapper;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using static Domain.Models.Enums.GuessType;

namespace Application.Commands.CreateExamCountry.IntegrationTests;

public class GenerateExamCountryCommandHandlerIntegrationTests
{

    private readonly KeepLearningDbContextTest _dbContext;
    private readonly CountryService _countryServiceTest;
    private readonly IMapper _mapper;

    public GenerateExamCountryCommandHandlerIntegrationTests()
    {
        var builder = new DbContextOptionsBuilder<KeepLearningDbContextTest>();
        builder.UseInMemoryDatabase("TestKeepLearningDb-CreateExamCountryCommandHandlerIntegrationTests");

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

    public static IEnumerable<object[]> GetCommands()
    {
        var list = new List<GenerateExamCountryQuery>()
        {
            new GenerateExamCountryQuery(){
                Name = "Exam 1",
                NumberOfQuestion = 5,
                Category = Category.Country,
                Continents = new List<string>() { "Europe", "Asia" }
            },
            new GenerateExamCountryQuery(){
                Name = "Exam 2",
                NumberOfQuestion = 10,
                Category = Category.Country,
                Continents = new List<string>() { "Europe", "Asia" }
            },
            new GenerateExamCountryQuery(){
                Name = "Exam 3",
                NumberOfQuestion = 25,
                Category = Category.Country,
                Continents = new List<string>() { "Europe", "Asia" }
            },
            new GenerateExamCountryQuery(){
                Name = "",
                NumberOfQuestion = 50,
                Category = Category.Country,
                Continents = new List<string>() { "Europe", "Asia" }
            },
        };

        return list.Select(el => new object[] { el });
    }

    [Theory()]
    [MemberData(nameof(GetCommands))]
    public async void Handle_CreateExamWithAllValidData_ReturnExam(GenerateExamCountryQuery createExamCountryCommand)
    {
        // arrange
        var createExamCountryCommandHandler = new GenerateExamCountryQueryHandler(_dbContext, _mapper, _countryServiceTest);
        var continents = createExamCountryCommand.Continents.Select(c => c);

        // act
        var result = await createExamCountryCommandHandler.Handle(createExamCountryCommand, CancellationToken.None);

        // assert
        result.Category.Should().Be(createExamCountryCommand.Category);
        result.Name.Should().Be(createExamCountryCommand.Name);
        result.Continents.Select(c => c.Name).All(createExamCountryCommand.Continents.Contains);
        result.Questions.Count().Should().Be(createExamCountryCommand.NumberOfQuestion);
    }

    public static IEnumerable<object[]> GetInvalidCommands()
    {
        var list = new List<GenerateExamCountryQuery>()
        {
            new GenerateExamCountryQuery(){
                Name = "Exam 1",
                NumberOfQuestion = 105,
                Category = Category.Country,
                Continents = new List<string>() { "Europe"}
            }
        };

        return list.Select(el => new object[] { el });
    }

    [Theory()]
    [MemberData(nameof(GetCommands))]
    public void Handle_CreateExamWithNumberOfQuestionIsBiggerThanCountriesInContinent_ReturnExam(GenerateExamCountryQuery createExamCountryCommand)
    {
        // arrange
        var createExamCountryCommandHandler = new GenerateExamCountryQueryHandler(_dbContext, _mapper, _countryServiceTest);
        var continents = createExamCountryCommand.Continents.Select(c => c);

        // act
        var action = () => createExamCountryCommandHandler.Handle(createExamCountryCommand, CancellationToken.None);

        // assert
        action.Invoking(action => action.Invoke())
            .Should().ThrowAsync<NotFoundException>();
    }
}