using KeepLearning.Application.Models.Enums;
using KeepLearning.Application.Models.TestCountry;
using MediatR;

namespace KeepLearning.Application.Queries.TestCountry
{
    public class GetTestCountryQuery : IRequest<TestCountryDto>
    {
        public string? Name { get; set; }
        public int NumberOfQuestion { get; set; } = 10;
        public GuessType.Value GuessType { get; set; } = default!;
        public IEnumerable<Continent.Name> Continents { get; set; } = new List<Continent.Name>();
    }
}
