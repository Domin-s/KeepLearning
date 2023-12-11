using KeepLearning.Application.Common.Models.Question;
using KeepLearning.Domain.Models.Enums;
using MediatR;

namespace KeepLearning.Application.Question.Queries.GetRandomQuestion
{
    public class GetRandomQuestionQuery : IRequest<QuestionDto>
    {
        public GuessType.Category Category { get; set; }
        public required string Continent { get; set; }
    }
}
