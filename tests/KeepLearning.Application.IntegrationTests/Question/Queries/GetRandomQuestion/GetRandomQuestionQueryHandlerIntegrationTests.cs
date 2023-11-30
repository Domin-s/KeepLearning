﻿using AutoMapper;
using KeepLearning.Application.Common.Mappings;
using KeepLearning.Application.Helper.Seeders.IntegrationTests;
using KeepLearning.Domain.Interfaces;
using KeepLearning.Infrastructure.Persistence;
using KeepLearning.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using static KeepLearning.Domain.Models.Enums.GuessType;

namespace KeepLearning.Application.Question.Queries.GetRandomQuestion.IntegrationTests
{
    public class GetRandomQuestionQueryHandlerIntegrationTests
    {
        private readonly KeepLearningDbContext _dbContext;
        private readonly IContinentRepository _continentRepositoryTest;
        private readonly ICountryRepository _countryRepositoryTest;
        private readonly IMapper _mapper;

        public GetRandomQuestionQueryHandlerIntegrationTests()
        {
            var builder = new DbContextOptionsBuilder<KeepLearningDbContext>();
            builder.UseInMemoryDatabase("TestKeepLearningDb-GetRandomQuestionQueryHandlerIntegrationTests");

            _dbContext = new KeepLearningDbContext(builder.Options);

            var continentSeederTest = new ContinentSeederTest(_dbContext);
            continentSeederTest.Seed();

            var countrySeederTest = new CountrySeederTest(_dbContext);
            countrySeederTest.Seed();

            _continentRepositoryTest = new ContinentRepository(_dbContext);
            _countryRepositoryTest = new CountryRepository(_dbContext);

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
                    Continent = "N. America",
                }
            };

            return list.Select(el => new object[] { el });
        }

        [Theory()]
        [MemberData(nameof(GetRandomQuestionQuerySamples))]
        public async void Handle_WithCorrectData_ReturnQuestion(GetRandomQuestionQuery getRandomQuestionQuery)
        {
            // arrange
            var getRandomQuestionQueryHandler = new GetRandomQuestionQueryHandler(_continentRepositoryTest, _countryRepositoryTest, _mapper);

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