using KeepLearning.Domain.Models.Enums;
using KeepLearning.Domain.Models.Question;
using KeepLearning.Domain.Commands.CreateTestCountry;

namespace KeepLearning.Domain.Models.Test.Country
{
    public class TestCountryDto : TestDto
    {
        public GuessType.Category Category { get; set; } = default!;
        public IEnumerable<Continent.Name> Continents { get; set; } = new List<Continent.Name>();

        public TestCountryDto()
        {

        }

        public TestCountryDto(CreateTestCountryCommand command, IEnumerable<QuestionDto> questions)
        {
            Name = command.Name;
            NumberOfQuestion = command.NumberOfQuestion;
            Continents = command.Continents;
            Questions = questions;
            Category = command.Category;
        }
    }
}
