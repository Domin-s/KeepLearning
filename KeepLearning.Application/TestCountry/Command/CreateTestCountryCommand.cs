using KeepLearning.Application.TestCountry.Models;
using MediatR;

namespace KeepLearning.Application.TestCountry.Command
{
    public class CreateTestCountryCommand : IRequest<TestCountryDto>
    {
        public string? Name { get; set; }
        public int NumberOfQuestion { get; set; }
        public IEnumerable<Continent.Name> Continents { get; set; } = new List<Continent.Name>();
    }
}
