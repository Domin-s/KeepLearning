using KeepLearning.Application.TestCountry.Models;
using MediatR;

namespace KeepLearning.Application.Country.Queries
{
    public class GetCountriesQuery : IRequest<IEnumerable<CountryDto>>
    {
        public IEnumerable<ContinentClass.Continent> Continents { get; set; } = new List<ContinentClass.Continent>();
    }
}
