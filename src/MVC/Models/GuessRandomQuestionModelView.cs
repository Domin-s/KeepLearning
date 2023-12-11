using Application.Common.Models.Question;
using Application.Question.Queries.GetRandomQuestion;

namespace MVC.Models
{
    public record GuessRandomQuestionModelView(GetRandomQuestionQuery GetRandomQuestionQuery, QuestionDto Question) { }
}
