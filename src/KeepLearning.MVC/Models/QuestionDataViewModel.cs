using KeepLearning.Application.Common.Models.Continent;
using KeepLearning.Domain.Models.Enums;

namespace KeepLearning.MVC.Models
{
    public class QuestionDataViewModel
    {
        public IEnumerable<ContinentViewModel> ContinentViewModel;
        public IEnumerable<string> Category;

        public QuestionDataViewModel(IEnumerable<ContinentDto> continents, IEnumerable<string> continentsChecked)
        {
            ContinentViewModel = continents.Select(c => new ContinentViewModel(c, continentsChecked));
            Category = GuessType.GetAllLikeStrings();
        }
    }
}
