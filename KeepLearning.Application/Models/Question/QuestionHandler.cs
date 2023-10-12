﻿using KeepLearning.Application.Models.Enums;

namespace KeepLearning.Application.Models.Question
{
    public static class QuestionHandler
    {
        public static QuestionDto FromCountryAndGuessType(Domain.Enteties.Country country, GuessType.Value guessType, int numberOfQuestion)
        {
            switch (guessType)
            {
                case GuessType.Value.CapitalCity:
                    return new QuestionDto(numberOfQuestion, country.Name);

                case GuessType.Value.Country:
                    return new QuestionDto(numberOfQuestion, country.CapitalCity);

                default:
                    throw new Exception("Wrong GuessType");
            }
        }

        public static IEnumerable<QuestionDto> FromCountriesAndGuessType(IEnumerable<Domain.Enteties.Country> countries, GuessType.Value guessType)
        {
            var questions = new List<QuestionDto>();
            var numberQuestion = 0;

            foreach (var item in countries)
            {
                questions.Add(FromCountryAndGuessType(item, guessType, numberQuestion++));
            }

            return questions;
        }
    }
}
