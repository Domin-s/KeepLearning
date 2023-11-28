using KeepLearning.Domain.Models.Enums;

namespace KeepLearning.Domain.Interfaces
{
    public interface ICountryService
    {
        public Task<string> GetCorrectAnswer(string questionText, GuessType.Category category);
        public Task<bool> IsCorrectAnswer(string questionText, string answerText, GuessType.Category category);
    }
}
