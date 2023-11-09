using KeepLearning.Domain.Models.Question;

namespace KeepLearning.Domain.Models.Test
{
    public class TestDto
    {
        public string? Name { get; set; }
        public int NumberOfQuestion { get; set; } = 10;
        public IEnumerable<QuestionDto> Questions { get; set; } = new List<QuestionDto>();
    }
}
