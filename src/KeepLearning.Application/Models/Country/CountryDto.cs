using KeepLearning.Domain.Models.Continent;

namespace KeepLearning.Domain.Models.Country
{
    public class CountryDto
    {
        public string Name { get; set; } = default!;
        public string CapitalCity { get; set; } = default!;
        public ContinentDto Continent { get; set; } = default!;
    }
}
