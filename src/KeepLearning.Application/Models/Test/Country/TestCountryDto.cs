using KeepLearning.Domain.Models.Enums;

namespace KeepLearning.Domain.Models.Test.Country
{
    public class TestCountryDto : TestDto
    {
        public GuessType.Category Category { get; set; } = default!;
        public IEnumerable<Continent.Name> Continents { get; set; } = new List<Continent.Name>();
    }
}
