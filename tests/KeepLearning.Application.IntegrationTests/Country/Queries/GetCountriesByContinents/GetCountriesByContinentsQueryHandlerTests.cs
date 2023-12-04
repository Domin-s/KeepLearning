using AutoMapper;
using KeepLearning.Application.Common.Mappings;
using KeepLearning.Application.Common.Models.Continent;
using KeepLearning.Application.Country.Queries.GetAllCountriesByContinents;
using KeepLearning.Application.Helper.Seeders.IntegrationTests;
using KeepLearning.Domain.Interfaces;
using KeepLearning.Infrastructure.Persistence;
using KeepLearning.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KeepLearning.Application.Country.Queries.GetCountriesByContinents.IntegrationTests
{
    public class GetCountriesByContinentsQueryHandlerTests
    {
        private readonly KeepLearningDbContext _dbContext;
        private readonly IContinentRepository _continentRepositoryTest;
        private readonly ICountryRepository _countryRepositoryTest;
        private readonly IMapper _mapper;

        public GetCountriesByContinentsQueryHandlerTests()
        {
            var builder = new DbContextOptionsBuilder<KeepLearningDbContext>();
            builder.UseInMemoryDatabase("TestKeepLearningDb-GetCountriesByContinentsQueryHandlerTests");

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

        public record QueryWithExpectedResult(GetAllCountriesByContinentsQuery getAllCountriesByContinentsQuery, int result) { }

        public static IEnumerable<object[]> GetQueryWithExpectedResult()
        {
            var list = new List<QueryWithExpectedResult>()
            {
                new QueryWithExpectedResult(
                    new GetAllCountriesByContinentsQuery(){
                            ContinentDtos = new List<ContinentDto>() {
                                new ContinentDto("Asia")
                            }
                    },
                    48
                ),
                new QueryWithExpectedResult(
                    new GetAllCountriesByContinentsQuery(){
                            ContinentDtos= new List<ContinentDto>() {
                                new ContinentDto("Asia"),
                                new ContinentDto("Europe")
                            }
                    },
                    92
                ),
                new QueryWithExpectedResult(
                    new GetAllCountriesByContinentsQuery(){
                            ContinentDtos= new List<ContinentDto>() {
                                new ContinentDto("Europe")
                            }
                    },
                    44
                ),
            };

            return list.Select(el => new object[] { el });
        }

        [Theory()]
        [MemberData(nameof(GetQueryWithExpectedResult))]
        public async void Handle_GetCountriesFromContients(QueryWithExpectedResult queryWithExpectedResult)
        {
            // arrange
            var handler = new GetAllCountriesByContinentsQueryHandler(_continentRepositoryTest, _countryRepositoryTest, _mapper);

            // act
            var result = await handler.Handle(queryWithExpectedResult.getAllCountriesByContinentsQuery, CancellationToken.None);

            // assert
            result.Count().Should().Be(queryWithExpectedResult.result);
        }

    }
}