using AutoMapper;
using Application.Common.Mappings;
using Application.Helper.Seeders.IntegrationTests;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using static Domain.Models.Enums.GuessType;
using Application.UnitTests.Helper;

namespace Application.Question.Queries.GetRandomQuestion.IntegrationTests
{
    public class GetRandomQuestionQueryHandlerIntegrationTests
    {
        private readonly KeepLearningDbContextTest _dbContext;
        private readonly CountryService _countryServiceTest;
        private readonly IMapper _mapper;

        public GetRandomQuestionQueryHandlerIntegrationTests()
        {
            var builder = new DbContextOptionsBuilder<KeepLearningDbContextTest>();
            builder.UseInMemoryDatabase("TestKeepLearningDb-GetRandomQuestionQueryHandlerIntegrationTests");

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
            var list = new List<GetRandomQuestionQuery>()
            {
                new GetRandomQuestionQuery()
                {
                    Category = Category.Country,
                    Continent = "Asia",
                },
                new GetRandomQuestionQuery()
                {
                    Category = Category.CapitalCity,
                    Continent = "Asia",
                },
                new GetRandomQuestionQuery()
                {
                    Category = Category.CapitalCity,
                    Continent = "Europe",
                },
                new GetRandomQuestionQuery()
                {
                    Category = Category.Country,
                    Continent = "North America",
                }
            };

            return list.Select(el => new object[] { el });
        }

        [Theory()]
        [MemberData(nameof(GetRandomQuestionQuerySamples))]
        public async void Handle_WithCorrectData_ReturnQuestion(GetRandomQuestionQuery getRandomQuestionQuery)
        {
            // arrange
            var getRandomQuestionQueryHandler = new GetRandomQuestionQueryHandler(_dbContext, _countryServiceTest, _mapper);

            // act
            var result = await getRandomQuestionQueryHandler.Handle(getRandomQuestionQuery, CancellationToken.None);

            // assert
            result.Should().NotBeNull();
            result.QuestionText.Should().NotBeNullOrWhiteSpace();
            result.AnswerText.Should().NotBeNullOrWhiteSpace();
            result.QuestionNumber.Should().Be(1);
        }
    }
}