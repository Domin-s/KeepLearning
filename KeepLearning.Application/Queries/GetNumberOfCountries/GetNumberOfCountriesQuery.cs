using KeepLearning.Application.Models.Enums;
using MediatR;

namespace KeepLearning.Application.Queries.GetNumberOfCountries
{
    public class GetNumberOfCountriesQuery: IRequest<int>
    {
        public IEnumerable<Continent.Name> Continents { get; set; } = new List<Continent.Name>();
    }
}
