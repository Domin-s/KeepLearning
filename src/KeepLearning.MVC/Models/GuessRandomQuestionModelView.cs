using KeepLearning.Application.Common.Models.Question;
using KeepLearning.Application.Question.Queries.GetRandomQuestion;

namespace KeepLearning.MVC.Models
{
    public record GuessRandomQuestionModelView(GetRandomQuestionQuery GetRandomQuestionQuery, QuestionDto Question) { }
}
