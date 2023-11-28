using KeepLearning.Domain.Models.Answer;
using KeepLearning.Domain.Models.Enums;
using KeepLearning.Domain.Models.Result.Exam;
using MediatR;

namespace KeepLearning.Domain.Queries.CheckExam
{
    public class CheckExamQuery : IRequest<ExamResultDto>
    {
        public GuessType.Category Category { get; set; }
        public required IEnumerable<AnswerDto> Answers { get; set; }
    }
}
