namespace KeepLearning.Domain.Models.Result.Test
{
    public record TestResultDto(IEnumerable<AnswerResultDto> AnswerResults, int NumberOfGoodAnswers, int NumberOfBadAnswers) { }
}
