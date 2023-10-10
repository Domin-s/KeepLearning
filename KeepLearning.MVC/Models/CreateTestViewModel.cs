using KeepLearning.Application.TestCountry.Command;
using KeepLearning.Application.TestCountry.Models;

namespace KeepLearning.MVC.Models
{
    public class CreateTestViewModel
    {
        public string? Name { get; set; }
        public int NumberOfQuestion { get; set; }
        public List<string> Continents { get; set; } = new List<string>();

        public GetTestCountryCommand ToCreateTestCountryCommand()
        {
            var continents = new List<Continent.Name>();

            foreach (var item in Continents)
            {
                var name = Continent.MapStringToContinent(item);
                continents.Add(name);
            }

            return new GetTestCountryCommand
            {
                Name = Name,
                NumberOfQuestion = NumberOfQuestion,
                Continents = continents
            };
        }
    }
}
