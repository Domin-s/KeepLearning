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
    }
}
