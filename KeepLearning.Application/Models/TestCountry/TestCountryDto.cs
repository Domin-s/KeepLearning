using KeepLearning.Application.Models.Question;

namespace KeepLearning.Application.Models.TestCountry
{
    public class TestCountryDto : TestCountryBase
    {
        public IEnumerable<QuestionDto> Questions { get; set; } = new List<QuestionDto>();
    }
}
