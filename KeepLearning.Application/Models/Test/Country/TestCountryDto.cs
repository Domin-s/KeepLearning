using KeepLearning.Domain.Models.Enums;
using KeepLearning.Domain.Models.Question;
using KeepLearning.Domain.Queries.CreateTestCountry;

namespace KeepLearning.Domain.Models.Test.Country
{
    public class TestCountryDto : TestDto
    {
        public GuessType.Value GuessType { get; set; } = default!;
        public IEnumerable<Continent.Name> Continents { get; set; } = new List<Continent.Name>();

        public TestCountryDto()
        {
            
        }

        public TestCountryDto(CreateTestCountryQuery query, IEnumerable<QuestionDto> questions)
        {
            Name = query.Name;
            NumberOfQuestion = query.NumberOfQuestion;
            Continents = query.Continents;
            Questions = questions;
            GuessType = query.GuessType;
        }
    }
}
