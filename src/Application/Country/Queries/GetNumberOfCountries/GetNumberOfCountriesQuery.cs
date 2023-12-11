using Application.Common.Models.Continent;
using MediatR;

namespace Application.Country.Queries.GetNumberOfCountries
{
    public class GetNumberOfCountriesQuery : IRequest<int>
    {
        public IEnumerable<ContinentDto> Continents { get; set; } = new List<ContinentDto>();
    }
}
