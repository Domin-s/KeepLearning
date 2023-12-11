using KeepLearning.Application.Common.Models.Question;

namespace KeepLearning.Application.Common.Models.Exam
{
    public class ExamDto
    {
        public string? Name { get; set; }
        public IEnumerable<QuestionDto> Questions { get; set; } = new List<QuestionDto>();
    }
}
