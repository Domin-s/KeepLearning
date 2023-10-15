using KeepLearning.Application.Models.Enums;

namespace KeepLearning.Application.Models.TestCountry
{
    public class TestCountryBase
    {
        public string? Name { get; set; }
        public int NumberOfQuestion { get; set; } = 10;
        public GuessType.Value GuessType { get; set; } = default!;
        public IEnumerable<Continent.Name> Continents { get; set; } = new List<Continent.Name>();
    }
}
