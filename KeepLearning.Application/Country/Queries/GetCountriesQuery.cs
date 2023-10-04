using MediatR;

namespace KeepLearning.Application.Country.Queries
{
    public class GetCountriesQuery : IRequest<IEnumerable<CountryDto>>
    {
        public IEnumerable<string> Continents { get; set; } = new List<string>();
    }
}
