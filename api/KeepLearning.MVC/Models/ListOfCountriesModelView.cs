using KeepLearning.Application.Common.Models.Continent;
using KeepLearning.Application.Common.Models.Country;

namespace KeepLearning.MVC.Models
{
    public record ListOfCountriesModelView(IEnumerable<CountryDto> CountryDtos, IEnumerable<ContinentDto> Continents) { }
}
