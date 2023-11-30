using KeepLearning.Application.Common.Models.Continent;
using KeepLearning.Application.FunctionalTests.Helper.Seeders;
using KeepLearning.Domain.Interfaces;
using KeepLearning.Infrastructure.Persistence;
using KeepLearning.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KeepLearning.Application.Country.Queries.GetNumberOfCountries.IntegrationTests
{
    public class GetNumberOfCountriesQueryHandlerTests
    {
        private readonly KeepLearningDbContext _dbContext;
        private readonly IContinentRepository _continentRepositoryTest;
        private readonly ICountryRepository _countryRepositoryTest;

        public GetNumberOfCountriesQueryHandlerTests()
        {
            var builder = new DbContextOptionsBuilder<KeepLearningDbContext>();
            builder.UseInMemoryDatabase("TestKeepLearningDb-GetNumberOfCountriesQueryHandlerTests");

            _dbContext = new KeepLearningDbContext(builder.Options);

            var continentSeederTest = new ContinentSeederTest(_dbContext);
            continentSeederTest.Seed();

            var countrySeederTest = new CountrySeederTest(_dbContext);
            countrySeederTest.Seed();

            _continentRepositoryTest = new ContinentRepository(_dbContext);
            _countryRepositoryTest = new CountryRepository(_dbContext);
        }

        public record QueryWithExpectedResult(GetNumberOfCountriesQuery getNumberOfCountriesQuery, int numbersOfCountries) { }

        public static IEnumerable<object[]> GetQueryWithExpectedResult()
        {
            var list = new List<QueryWithExpectedResult>()
            {
                new QueryWithExpectedResult(
                    new GetNumberOfCountriesQuery(){
                            Continents= new List<ContinentDto>() {
                                new ContinentDto("Asia")
                            }
                    },
                    48
                ),
                new QueryWithExpectedResult(
                    new GetNumberOfCountriesQuery(){
                            Continents= new List<ContinentDto>() {
                                new ContinentDto("Asia"),
                                new ContinentDto("Europe")
                            }
                    },
                    92
                ),
                new QueryWithExpectedResult(
                    new GetNumberOfCountriesQuery(){
                            Continents= new List<ContinentDto>() {
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
        public async void Handle_GetSpecificNumberOfCountries_ForMoreOrQuealContinent(QueryWithExpectedResult queryWithExpectedResult)
        {
            // arrange
            var handler = new GetNumberOfCountriesQueryHandler(_continentRepositoryTest, _countryRepositoryTest);

            // act
            var result = await handler.Handle(queryWithExpectedResult.getNumberOfCountriesQuery, CancellationToken.None);

            // assert
            result.Should().Be(queryWithExpectedResult.numbersOfCountries);
        }

    }
}