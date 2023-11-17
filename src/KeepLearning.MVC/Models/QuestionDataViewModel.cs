using KeepLearning.Domain.Models.Enums;

namespace KeepLearning.MVC.Models
{
    public class QuestionDataViewModel
    {
        public IEnumerable<string> Continents;
        public IEnumerable<string> Category;

        public QuestionDataViewModel()
        {
            Continents = Continent.GetAllLikeStrings();
            Category = GuessType.GetAllLikeStrings();
        }
    }
}
