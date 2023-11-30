using KeepLearning.Application.Common.Models.Continent;

namespace KeepLearning.Application.Common.Models.Country
{
    public class CountryDto
    {
        public required string Name { get; set; }
        public required string Abbreviation { get; set; }
        public required string CapitalCity { get; set; }
        public ContinentDto? ContinentDto { get; set; }
    }
}
