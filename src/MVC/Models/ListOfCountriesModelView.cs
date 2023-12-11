using Application.Common.Models.Continent;
using Application.Common.Models.Country;

namespace MVC.Models
{
    public record ListOfCountriesModelView(IEnumerable<CountryDto> CountryDtos, IEnumerable<ContinentDto> Continents) { }
}
