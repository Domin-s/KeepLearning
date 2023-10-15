using KeepLearning.Application.Models.Enums;
using KeepLearning.Application.Models.Question;
using MediatR;

namespace KeepLearning.Application.Queries.GetRandomQuestion
{
    public class GetRandomQuestionQuery : IRequest<QuestionDto>
    {
        public GuessType.Value GuessType { get; set; }
        public Continent.Name Continent { get; set; }
    }
}
