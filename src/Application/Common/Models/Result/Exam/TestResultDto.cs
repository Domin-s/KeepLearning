using Application.Common.Models.Result.Answer;

namespace Application.Common.Models.Result.Exam
{
    public record ExamResultDto(IEnumerable<AnswerResultDto> AnswerResults, int NumberOfGoodAnswers, int NumberOfBadAnswers) { }
}
