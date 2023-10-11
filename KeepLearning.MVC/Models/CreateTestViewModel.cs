using KeepLearning.Application.Models.Enums;
using KeepLearning.Application.Queries.TestCountry;

namespace KeepLearning.MVC.Models
{
    public class CreateTestViewModel
    {
        public string? Name { get; set; }
        public int NumberOfQuestion { get; set; }
        public List<string> Continents { get; set; } = new List<string>();

        public GetTestCountryQuery ToCreateTestCountryCommand()
        {
            var continents = new List<Continent.Name>();

            foreach (var item in Continents)
            {
                var name = Continent.MapStringToContinent(item);
                continents.Add(name);
            }

            return new GetTestCountryQuery
            {
                Name = Name,
                NumberOfQuestion = NumberOfQuestion,
                Continents = continents
            };
        }
    }
}
