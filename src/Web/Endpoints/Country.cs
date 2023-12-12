using Application.Common.Models.Country;
using Application.Country.Queries.GetAllCountriesByContinents;
using Application.Country.Queries.GetNumberOfCountries;

namespace Web.Endpoints
{
    public class Country : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
            .MapGet(GetCountries)
            .MapGet(GetNumberOfCountries, "numberOfCountries");
        }

        public async Task<IEnumerable<CountryDto>> GetCountries(ISender sender, [AsParameters] GetAllCountriesByContinentsQuery query)
        {
            return await sender.Send(query);
        }

        public async Task<int> GetNumberOfCountries(ISender sender, [AsParameters] GetNumberOfCountriesQuery query)
        {
            return await sender.Send(query);
        }
    }
}