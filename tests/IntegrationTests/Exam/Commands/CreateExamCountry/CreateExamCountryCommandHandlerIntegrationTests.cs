using AutoMapper;
using Application.Common.Mappings;
using Application.Helper.Seeders.IntegrationTests;
using Domain.Enteties;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using static Domain.Models.Enums.GuessType;

namespace Domain.Commands.CreateExamCountry.IntegrationTests
{
    public class CreateExamCountryCommandHandlerIntegrationTests
    {

        private readonly KeepLearningDbContext _dbContext;
        private readonly IContinentRepository _continentRepositoryTest;
        private readonly ICountryRepository _countryRepositoryTest;
        private readonly ICountryService _countryServiceTest;
        private readonly IMapper _mapper;

        public CreateExamCountryCommandHandlerIntegrationTests()
        {
            var builder = new DbContextOptionsBuilder<KeepLearningDbContext>();
            builder.UseInMemoryDatabase("TestKeepLearningDb-CreateExamCountryCommandHandlerIntegrationTests");

            _dbContext = new KeepLearningDbContext(builder.Options);

            var continentSeederTest = new ContinentSeederTest(_dbContext);
            continentSeederTest.Seed();

            var countrySeederTest = new CountrySeederTest(_dbContext);
            countrySeederTest.Seed();

            _continentRepositoryTest = new ContinentRepository(_dbContext);
            _countryRepositoryTest = new CountryRepository(_dbContext);
            _countryServiceTest = new CountryService(_countryRepositoryTest);

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
            var list = new List<CreateExamCountryCommand>()
            {
                new CreateExamCountryCommand(){
                    Name = "Exam 1",
                    NumberOfQuestion = 5,
                    Category = Category.Country,
                    Continents = new List<string>() { "Europe", "Asia" }
                },
                new CreateExamCountryCommand(){
                    Name = "Exam 2",
                    NumberOfQuestion = 10,
                    Category = Category.Country,
                    Continents = new List<string>() { "Europe", "Asia" }
                },
                new CreateExamCountryCommand(){
                    Name = "Exam 3",
                    NumberOfQuestion = 25,
                    Category = Category.Country,
                    Continents = new List<string>() { "Europe", "Asia" }
                },
                new CreateExamCountryCommand(){
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
        public async void Handle_CreateExamWithAllValidData_ReturnExam(CreateExamCountryCommand createExamCountryCommand)
        {
            // arrange
            var createExamCountryCommandHandler = new CreateExamCountryCommandHandler(_continentRepositoryTest, _countryServiceTest, _mapper);
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
            var list = new List<CreateExamCountryCommand>()
            {
                new CreateExamCountryCommand(){
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
        public void Handle_CreateExamWithNumberOfQuestionIsBiggerThanCountriesInContinent_ReturnExam(CreateExamCountryCommand createExamCountryCommand)
        {
            // arrange
            var createExamCountryCommandHandler = new CreateExamCountryCommandHandler(_continentRepositoryTest, _countryServiceTest, _mapper);
            var continents = createExamCountryCommand.Continents.Select(c => c);

            // act
            var action = () => createExamCountryCommandHandler.Handle(createExamCountryCommand, CancellationToken.None);

            // assert
            action.Invoking(action => action.Invoke())
                .Should().ThrowAsync<Exceptions.InvalidDataException>();
        }
    }
}