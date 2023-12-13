namespace Domain.Enteties;

public class Country
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Abbreviation { get; set; }
    public required string CapitalCity { get; set; }
    public required Guid ContinentId { get; set; }
    public Continent? Continent { get; set; }
}
