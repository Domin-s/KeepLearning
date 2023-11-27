using KeepLearning.Domain.Enteties;
using KeepLearning.Domain.Models.Enums;
using KeepLearning.Domain.Models.Question;
using MediatR;

namespace KeepLearning.Domain.Queries.GetRandomQuestion
{
    public class GetRandomQuestionQuery : IRequest<QuestionDto>
    {
        public GuessType.Category Category { get; set; }
        public required Continent Continent { get; set; }
    }
}
