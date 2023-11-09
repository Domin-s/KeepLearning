using KeepLearning.Domain.Models.Question;
using KeepLearning.Domain.Queries.GetRandomQuestion;

namespace KeepLearning.MVC.Models
{
    public record GuessRandomQuestionModelView(GetRandomQuestionQuery GetRandomQuestionQuery, QuestionDto Question) { }
}
