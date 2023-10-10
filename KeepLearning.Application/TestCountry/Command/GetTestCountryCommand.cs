using KeepLearning.Application.TestCountry.Models;
using MediatR;

namespace KeepLearning.Application.TestCountry.Command
{
    public class GetTestCountryCommand : IRequest<TestCountryDto>
    {
        public string? Name { get; set; }
        public int NumberOfQuestion { get; set; } = 10;
        public GuessType GuessType { get; set; } = default!;
        public IEnumerable<Continent.Name> Continents { get; set; } = new List<Continent.Name>();
    }
}
