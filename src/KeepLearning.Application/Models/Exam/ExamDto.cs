using KeepLearning.Domain.Models.Question;

namespace KeepLearning.Domain.Models.Exam
{
    public class ExamDto
    {
        public string? Name { get; set; }
        public IEnumerable<QuestionDto> Questions { get; set; } = new List<QuestionDto>();
    }
}
