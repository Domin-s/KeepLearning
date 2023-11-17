using KeepLearning.Domain.Models.Enums;

namespace KeepLearning.Domain.Interfaces
{
    public interface ICountryService
    {
        public Task<Domain.Enteties.Country> GetRandomCountry(IEnumerable<Continent.Name> continents);
        public Task<IEnumerable<Domain.Enteties.Country>> GetRandomCountries(IEnumerable<Continent.Name> continents, int numberOfQuestions);
        public Task<Domain.Enteties.Country?> GetCountry(string questionText, GuessType.Category category);
        public Task<string> GetCorrectAnswer(string questionText, GuessType.Category category);
        public Task<IEnumerable<Domain.Enteties.Country>> GetCountries(IEnumerable<Continent.Name> continents);
        public bool IsCorrectAnswer(Domain.Enteties.Country country, string answerText, GuessType.Category category);
    }
}
