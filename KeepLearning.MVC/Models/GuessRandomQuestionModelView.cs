using KeepLearning.Application.Models.Question;
using KeepLearning.Application.Queries.GetRandomQuestion;

namespace KeepLearning.MVC.Models
{
    public record GuessRandomQuestionModelView(GetRandomQuestionQuery GetRandomQuestionQuery, QuestionDto Question) { }
}
