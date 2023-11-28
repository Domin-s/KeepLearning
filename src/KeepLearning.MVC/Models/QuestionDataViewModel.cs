using KeepLearning.Application.Common.Models.Continent;
using KeepLearning.Domain.Models.Enums;

namespace KeepLearning.MVC.Models
{
    public class QuestionDataViewModel
    {
        public IEnumerable<string> Continents;
        public IEnumerable<string> Category;

        public QuestionDataViewModel(IEnumerable<ContinentDto> continents)
        {
            Continents = continents.Select(c => c.Name);
            Category = GuessType.GetAllLikeStrings();
        }
    }
}
