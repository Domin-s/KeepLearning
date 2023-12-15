namespace Application.Country.Queries.GetAllCountriesByContinents;

public abstract class CountriesByContinents
{
    public IEnumerable<string> Continents { get; set; } = new List<string>();
}
