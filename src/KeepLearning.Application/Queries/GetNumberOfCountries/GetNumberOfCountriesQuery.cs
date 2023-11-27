using KeepLearning.Domain.Enteties;
using MediatR;

namespace KeepLearning.Domain.Queries.GetNumberOfCountries
{
    public class GetNumberOfCountriesQuery : IRequest<int>
    {
        public IEnumerable<Continent> Continents { get; set; } = new List<Continent>();
    }
}
