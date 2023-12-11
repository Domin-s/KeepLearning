using KeepLearning.Application.Common.Models.Continent;

namespace KeepLearning.MVC.Models
{
    public class ContinentViewModel
    {
        public ContinentDto ContinentDto;
        public bool IsChecked;

        public ContinentViewModel(ContinentDto continentDto, IEnumerable<string> continentsChecked)
        {
            ContinentDto = continentDto;
            IsChecked = IsCheckedContinent(continentDto, continentsChecked);
        }

        private bool IsCheckedContinent(ContinentDto continentDto, IEnumerable<string> continentsChecked)
        {
            if (continentsChecked.Contains(continentDto.Name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
