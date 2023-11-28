using KeepLearning.Domain.Models.Continent;
using MediatR;

namespace KeepLearning.Domain.Queries.GetNumberOfCountries
{
    public class GetNumberOfCountriesQuery : IRequest<int>
    {
        public IEnumerable<ContinentDto> Continents { get; set; } = new List<ContinentDto>();
    }
}
