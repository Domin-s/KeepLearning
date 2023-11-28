using KeepLearning.Domain.Commands.CreateExamCountry;
using KeepLearning.Domain.Exceptions;
using KeepLearning.Domain.Models.Country;
using KeepLearning.Domain.Models.Enums;
using KeepLearning.Domain.Models.Question;

namespace KeepLearning.Domain.Models
{
    public static class QuestionDtoBuilder
    {
        public static List<QuestionDto> CreateQuestions(List<CountryDto> countries, CreateExamCountryCommand command)
        {
            var questions = new List<QuestionDto>() { };

            for (var i = 0; i < countries.Count(); i++)
            {
                var newQuestion = CreateQuestionByCategory(countries[i], command.Category, i + 1);
                questions.Add(newQuestion);
            }

            return questions;
        }

        public static QuestionDto CreateQuestionByCategory(CountryDto country, GuessType.Category category, int questionNumber = 1)
        {
            switch (category)
            {
                case GuessType.Category.CapitalCity:
                    return new QuestionDto(questionNumber, country.Name, country.CapitalCity);
                case GuessType.Category.Country:
                    return new QuestionDto(questionNumber, country.CapitalCity, country.Name);
                default:
                    throw new NotFoundCaseException("Choosen category not exists");
            }
        }
    }
}