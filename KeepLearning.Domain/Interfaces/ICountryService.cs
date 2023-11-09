using KeepLearning.Domain.Models;
using KeepLearning.Domain.Models.Enums;

namespace KeepLearning.Domain.Interfaces
{
    public interface ICountryService
    {
        public Domain.Enteties.Country GetRandomCountry(IEnumerable<Domain.Enteties.Country> ListOfCountry);
        public IEnumerable<Domain.Enteties.Country> GetRandomCountries(int numberOfQuestions);
        public Task<Domain.Enteties.Country?> GetCountry(string questionText, GuessType.Value guessType);
        public Task<Countries> GetCountries(IEnumerable<Continent.Name> continents);
        public bool IsCorrectAnswer(Domain.Enteties.Country country, string answerText, GuessType.Value guessType);
    }
}
