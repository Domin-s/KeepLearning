using Application.Common.Models.Answer;
using Application.Common.Models.Result.Exam;
using Domain.Models.Enums;
using MediatR;

namespace Application.Exam.Queries.CheckExam
{
    public class CheckExamQuery : IRequest<ExamResultDto>
    {
        public GuessType.Category Category { get; set; }
        public required IEnumerable<AnswerDto> Answers { get; set; }
    }
}
