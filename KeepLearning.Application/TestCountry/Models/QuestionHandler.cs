using KeepLearning.Domain.Enteties;

namespace KeepLearning.Application.TestCountry.Models
{
    public static class QuestionHandler
    {
        public static QuestionDto FromCountryAndGuessType(Domain.Enteties.Country country, GuessType guessType)
        {
            switch (guessType)
            {
                case GuessType.GuessCapitalCity:
                    return new QuestionDto(country.Name, country.CapitalCity);

                case GuessType.GuessCountry:
                    return new QuestionDto(country.CapitalCity, country.Name);

                default:
                    throw new Exception("Wrong GuessType");
            }
        }

        public static IEnumerable<QuestionDto> FromCountriesAndGuessType(IEnumerable<Domain.Enteties.Country> countries, GuessType guessType)
        {
            var questions = new List<QuestionDto>();

            foreach (var item in countries)
            {
                questions.Add(FromCountryAndGuessType(item, guessType));
            }

            return questions;
        }
    }
}
