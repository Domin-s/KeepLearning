using KeepLearning.Application.Models.Enums;
using KeepLearning.Application.Models.Question;

namespace KeepLearning.Application.Models.TestCountry
{
    public class TestCountryDto
    {
        public string? Name { get; set; }
        public int NumberOfQuestion { get; set; }
        public IEnumerable<Continent.Name> Continents { get; set; } = Enumerable.Empty<Continent.Name>();
        public IEnumerable<QuestionDto> Questions { get; set; } = new List<QuestionDto>();
    }
}
