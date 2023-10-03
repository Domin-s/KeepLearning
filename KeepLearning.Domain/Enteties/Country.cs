namespace KeepLearning.Domain.Enteties
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Abbreviation { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string CapitalCity { get; set; } = default!;
        public string Continent { get; set; } = default!;
    }
}
