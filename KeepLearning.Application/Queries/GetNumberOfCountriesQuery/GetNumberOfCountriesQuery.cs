using KeepLearning.Application.Models.Enums;
using MediatR;

namespace KeepLearning.Application.Queries.GetNumberOfCountriesQuery
{
    public class GetNumberOfCountriesQuery: IRequest<int>
    {
        public IEnumerable<Continent.Name> Continents { get; set; } = new List<Continent.Name>();
    }
}
