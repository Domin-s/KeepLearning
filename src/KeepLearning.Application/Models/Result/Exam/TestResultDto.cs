namespace KeepLearning.Domain.Models.Result.Exam
{
    public record ExamResultDto(IEnumerable<AnswerResultDto> AnswerResults, int NumberOfGoodAnswers, int NumberOfBadAnswers) { }
}
