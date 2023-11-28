using KeepLearning.Domain.Enteties;
using KeepLearning.Domain.Models;
using MediatR;

namespace KeepLearning.Application.Country.Queries.GetCountries
{
    public class GetCountriesQuery : IRequest<Countries>
    {
        public IEnumerable<Continent> Continents { get; set; } = new List<Continent>();
    }
}
