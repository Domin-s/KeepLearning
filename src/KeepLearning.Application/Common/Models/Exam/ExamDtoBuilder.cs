using KeepLearning.Application.Common.Models.Continent;
using KeepLearning.Application.Common.Models.Exam.Country;
using KeepLearning.Application.Common.Models.Question;
using static KeepLearning.Domain.Models.Enums.GuessType;

namespace KeepLearning.Application.Common.Models.Exam
{
    public static class ExamDtoBuilder
    {

        public static ExamDto CreateExam(string? name, List<QuestionDto> questions)
        {
            var examDto = new ExamDto()
            {
                Name = name,
                Questions = questions
            };

            return examDto;
        }

        public static ExamCountryDto CreateExamCountry(string? name, List<QuestionDto> questions, Category category, List<ContinentDto> continents)
        {
            var examDto = new ExamCountryDto()
            {
                Name = name,
                Questions = questions,
                Category = category,
                Continents = continents
            };

            return examDto;
        }
    }
}