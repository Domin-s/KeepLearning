using KeepLearning.Domain.Models;
using KeepLearning.Domain.Models.Enums;
using MediatR;

namespace KeepLearning.Domain.Queries.GetCountries
{
    public class GetCountriesQuery : IRequest<Countries>
    {
        public IEnumerable<Continent.Name> Continents { get; set; } = new List<Continent.Name>();
    }
}
