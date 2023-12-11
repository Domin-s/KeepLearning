using KeepLearning.Application.Common.Models.Result.Answer;

namespace KeepLearning.Application.Common.Models.Result.Exam
{
    public record ExamResultDto(IEnumerable<AnswerResultDto> AnswerResults, int NumberOfGoodAnswers, int NumberOfBadAnswers) { }
}
