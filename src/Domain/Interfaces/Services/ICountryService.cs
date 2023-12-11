using Domain.Enteties;
using Domain.Models.Enums;

namespace Domain.Interfaces
{
    public interface ICountryService
    {
        public Task<Country?> GetRandom(Guid continentId);
        public Task<IEnumerable<Country>> RandomCountries(IEnumerable<Guid> continentIds, int numberOfCountries);
        public Task<string> GetCorrectAnswer(string questionText, GuessType.Category category);
        public Task<bool> IsCorrectAnswer(string questionText, string answerText, GuessType.Category category);
    }
}
