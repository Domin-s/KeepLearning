using KeepLearning.Application.TestCountry.Models;
using MediatR;

namespace KeepLearning.Application.Country.Queries
{
    public class GetCountriesQuery : IRequest<Countries>
    {
        public IEnumerable<Continent.Name> Continents { get; set; } = new List<Continent.Name>();
    }
}
