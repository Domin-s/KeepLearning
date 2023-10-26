using KeepLearning.Application.Models.Question;

namespace KeepLearning.Application.Models.Answer
{
    public class AnswerDto
    {
        public required QuestionDto Question { get; set; }
        public string? AnswerText { get; set; }
    }
}
