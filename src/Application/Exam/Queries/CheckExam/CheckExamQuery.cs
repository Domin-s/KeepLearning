using KeepLearning.Application.Common.Models.Answer;
using KeepLearning.Application.Common.Models.Result.Exam;
using KeepLearning.Domain.Models.Enums;
using MediatR;

namespace KeepLearning.Application.Exam.Queries.CheckExam
{
    public class CheckExamQuery : IRequest<ExamResultDto>
    {
        public GuessType.Category Category { get; set; }
        public required IEnumerable<AnswerDto> Answers { get; set; }
    }
}
