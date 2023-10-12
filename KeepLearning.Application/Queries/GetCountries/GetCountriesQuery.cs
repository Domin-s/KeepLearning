using KeepLearning.Application.Country;
using KeepLearning.Application.Models.Enums;
using MediatR;

namespace KeepLearning.Application.Queries.GetCountries
{
    public class GetCountriesQuery : IRequest<Countries>
    {
        public IEnumerable<Continent.Name> Continents { get; set; } = new List<Continent.Name>();
    }
}
