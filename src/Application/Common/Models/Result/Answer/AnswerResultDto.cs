namespace Application.Common.Models.Result.Answer
{
    public record AnswerResultDto(int NumberOfQuestion, string? userAnswer, string CorrectAnswer) { }
}
