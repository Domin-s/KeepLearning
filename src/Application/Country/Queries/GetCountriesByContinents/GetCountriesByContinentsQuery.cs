using Application.Common.Models.Country;

namespace Application.Country.Queries.GetAllCountriesByContinents;

public class GetCountriesByContinentsQuery : CountriesByContinents, IRequest<IEnumerable<CountryDto>> { }
