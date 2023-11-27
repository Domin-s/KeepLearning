using KeepLearning.Domain.Enteties;
using KeepLearning.Domain.Models;
using MediatR;

namespace KeepLearning.Domain.Queries.GetCountries
{
    public class GetCountriesQuery : IRequest<Countries>
    {
        public IEnumerable<Continent> Continents { get; set; } = new List<Continent>();
    }
}
