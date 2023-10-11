namespace KeepLearning.MVC.Models
{
    public record RandomQuestionViewModel(IEnumerable<string> Continents, IEnumerable<string> GuessTypes) { }
}
