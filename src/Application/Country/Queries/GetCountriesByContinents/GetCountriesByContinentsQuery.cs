using Application.Common.Models.Continent;
using Application.Common.Models.Country;

namespace Application.Country.Queries.GetAllCountriesByContinents;

public class GetCountriesByContinentsQuery : IRequest<IEnumerable<CountryDto>>
{
    public IEnumerable<ContinentDto> ContinentDtos { get; set; } = new List<ContinentDto>();
}
