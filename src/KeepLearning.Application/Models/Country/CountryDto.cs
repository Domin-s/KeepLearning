using KeepLearning.Domain.Models.Continent;

namespace KeepLearning.Domain.Models.Country
{
    public class CountryDto
    {
        public required string Name { get; set; }
        public required string Abbreviation { get; set; }
        public required string CapitalCity { get; set; }
        public required ContinentDto Continent { get; set; }
    }
}
