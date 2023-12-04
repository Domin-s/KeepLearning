using KeepLearning.Application.Common.Models.Continent;
using KeepLearning.Application.Common.Models.Country;
using MediatR;

namespace KeepLearning.Application.Country.Queries.GetAllCountriesByContinents
{
    public class GetAllCountriesByContinentsQuery : IRequest<IEnumerable<CountryDto>>
    {
        public IEnumerable<ContinentDto> ContinentDtos { get; set; } = new List<ContinentDto>();
    }
}