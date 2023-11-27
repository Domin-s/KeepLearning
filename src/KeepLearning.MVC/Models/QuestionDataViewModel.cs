using KeepLearning.Domain.Models.Enums;

namespace KeepLearning.MVC.Models
{
    public class QuestionDataViewModel
    {
        public IEnumerable<string> Continents;
        public IEnumerable<string> Category;

        public QuestionDataViewModel(IEnumerable<string> continents)
        {
            Continents = continents;
            Category = GuessType.GetAllLikeStrings();
        }
    }
}
