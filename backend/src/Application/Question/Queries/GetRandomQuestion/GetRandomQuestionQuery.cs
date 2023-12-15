using Application.Common.Models.Question;
using Domain.Models.Enums;

namespace Application.Question.Queries.GetRandomQuestion;

public class GetRandomQuestionQuery : IRequest<QuestionDto>
{
    public GuessType.Category Category { get; set; }
    public required string Continent { get; set; }
}
