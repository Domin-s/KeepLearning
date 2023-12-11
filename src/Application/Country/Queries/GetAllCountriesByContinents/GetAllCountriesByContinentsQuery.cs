using Application.Common.Models.Continent;
using Application.Common.Models.Country;
using MediatR;

namespace Application.Country.Queries.GetAllCountriesByContinents
{
    public class GetAllCountriesByContinentsQuery : IRequest<IEnumerable<CountryDto>>
    {
        public IEnumerable<ContinentDto> ContinentDtos { get; set; } = new List<ContinentDto>();
    }
}