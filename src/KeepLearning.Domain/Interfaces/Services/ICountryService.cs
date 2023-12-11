using KeepLearning.Domain.Enteties;
using KeepLearning.Domain.Models.Enums;

namespace KeepLearning.Domain.Interfaces
{
    public interface ICountryService
    {
        public Task<Country?> GetRandom(Guid continentId);
        public Task<IEnumerable<Country>> RandomCountries(IEnumerable<Guid> continentIds, int numberOfCountries);
        public Task<string> GetCorrectAnswer(string questionText, GuessType.Category category);
        public Task<bool> IsCorrectAnswer(string questionText, string answerText, GuessType.Category category);
    }
}
