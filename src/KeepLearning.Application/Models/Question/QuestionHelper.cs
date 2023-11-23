using KeepLearning.Domain.Models.Enums;

namespace KeepLearning.Domain.Models.Question
{
    public static class QuestionHelper
    {
        public static QuestionDto FromCountryAndGuessType(Domain.Enteties.Country country, GuessType.Category guessType, int numberOfQuestion = 1)
        {
            switch (guessType)
            {
                case GuessType.Category.CapitalCity:
                    return new QuestionDto(numberOfQuestion, country.Name);

                case GuessType.Category.Country:
                    return new QuestionDto(numberOfQuestion, country.CapitalCity);

                default:
                    throw new NotImplementedException();
            }
        }

        public static IEnumerable<QuestionDto> FromCountriesAndGuessType(IEnumerable<Domain.Enteties.Country> countries, GuessType.Category guessType)
        {
            var questions = new List<QuestionDto>();
            var numberQuestion = 1;

            foreach (var item in countries)
            {
                questions.Add(FromCountryAndGuessType(item, guessType, numberQuestion++));
            }

            return questions;
        }
    }
}
