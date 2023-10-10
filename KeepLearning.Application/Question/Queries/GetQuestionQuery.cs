using KeepLearning.Application.TestCountry.Models;
using MediatR;

namespace KeepLearning.Application.Question.Queries
{
    public class GetQuestionQuery: IRequest<QuestionDto>
    {
        public GuessType GuessType { get; set; }
        public Continent.Name Continent { get; set; }
    }
}
