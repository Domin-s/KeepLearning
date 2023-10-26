using KeepLearning.Application.Models.Enums;

namespace KeepLearning.Application.Models.Test.Country
{
    public class TestCountryDto : TestDto
    {
        public GuessType.Value GuessType { get; set; } = default!;
        public IEnumerable<Continent.Name> Continents { get; set; } = new List<Continent.Name>();
    }
}
