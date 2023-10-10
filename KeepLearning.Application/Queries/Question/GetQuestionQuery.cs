using KeepLearning.Application.Models.Enums;
using KeepLearning.Application.Models.Question;
using MediatR;

namespace KeepLearning.Application.Queries.Question
{
    public class GetQuestionQuery : IRequest<QuestionDto>
    {
        public GuessType GuessType { get; set; }
        public Continent.Name Continent { get; set; }
    }
}
