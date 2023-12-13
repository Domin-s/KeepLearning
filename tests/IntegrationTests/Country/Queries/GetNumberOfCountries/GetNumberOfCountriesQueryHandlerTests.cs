using Application.Common.Models.Continent;
using Application.Helper.Seeders.IntegrationTests;
using Application.UnitTests.Helper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Country.Queries.GetNumberOfCountries.IntegrationTests
{
    public class GetNumberOfCountriesQueryHandlerTests
    {
        private readonly KeepLearningDbContextTest _dbContext;

        public GetNumberOfCountriesQueryHandlerTests()
        {
            var builder = new DbContextOptionsBuilder<KeepLearningDbContextTest>();
            builder.UseInMemoryDatabase("TestKeepLearningDb-GetNumberOfCountriesQueryHandlerTests");

            _dbContext = new KeepLearningDbContextTest(builder.Options);

            var continentSeederTest = new ContinentSeederTest(_dbContext);
            continentSeederTest.Seed();

            var countrySeederTest = new CountrySeederTest(_dbContext);
            countrySeederTest.Seed();
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
            var handler = new GetNumberOfCountriesQueryHandler(_dbContext);

            // act
            var result = await handler.Handle(queryWithExpectedResult.getNumberOfCountriesQuery, CancellationToken.None);

            // assert
            result.Should().Be(queryWithExpectedResult.numbersOfCountries);
        }

    }
}