using KeepLearning.Application.TestCountry.Command;

namespace KeepLearning.Application.TestCountry.Models
{
    abstract public class TestCountryBasic
    {
        public string? Name { get; set; }
        public int NumberOfQuestion { get; set; }
        public IEnumerable<ContinentClass.Continent> Continents { get; set; } = new List<ContinentClass.Continent>();
    }
}
