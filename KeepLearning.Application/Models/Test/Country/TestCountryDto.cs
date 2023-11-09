using KeepLearning.Domain.Models.Enums;
using KeepLearning.Domain.Models.Question;
using KeepLearning.Domain.Queries.CreateTestCountry;

namespace KeepLearning.Domain.Models.Test.Country
{
    public class TestCountryDto : TestDto
    {
        public GuessType.Value GuessType { get; set; } = default!;
        public IEnumerable<Continent.Name> Continents { get; set; } = new List<Continent.Name>();

        public TestCountryDto(CreateTestCountryQuery command, IEnumerable<QuestionDto> questions)
        {
            Name = command.Name;
            NumberOfQuestion = command.NumberOfQuestion;
            Continents = command.Continents;
            Questions = questions;
            GuessType = command.GuessType;
        }
    }
}
