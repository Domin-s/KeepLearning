using KeepLearning.Domain.Models.Enums;

namespace KeepLearning.MVC.Models
{
    public class QuestionDataViewModel
    {
        public IEnumerable<string> Continents;
        public IEnumerable<string> GuessTypes;
        
        public QuestionDataViewModel()
        {
            Continents = Continent.GetAllLikeStrings();
            GuessTypes = GuessType.GetAllLikeStrings();
        }
    }
}
