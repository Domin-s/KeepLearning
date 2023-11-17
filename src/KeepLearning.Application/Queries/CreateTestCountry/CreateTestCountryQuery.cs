using KeepLearning.Domain.Models.Enums;
using KeepLearning.Domain.Models.Test.Country;
using MediatR;

namespace KeepLearning.Domain.Queries.CreateTestCountry
{
    public class CreateTestCountryQuery : IRequest<TestCountryDto>
    {
        public string? Name { get; set; }
        public int NumberOfQuestion { get; set; } = 10;
        public GuessType.Category Category { get; set; } = default!;
        public IEnumerable<Continent.Name> Continents { get; set; } = new List<Continent.Name>();
    }
}
