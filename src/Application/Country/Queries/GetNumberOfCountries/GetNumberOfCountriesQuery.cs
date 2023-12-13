using Application.Country.Queries.GetAllCountriesByContinents;

namespace Application.Country.Queries.GetNumberOfCountries;

public class GetNumberOfCountriesQuery : CountriesByContinents, IRequest<int> { }
