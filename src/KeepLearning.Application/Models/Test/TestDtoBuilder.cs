using KeepLearning.Domain.Models.Continent;
using KeepLearning.Domain.Models.Enums;
using KeepLearning.Domain.Models.Question;
using KeepLearning.Domain.Models.Test.Country;

namespace KeepLearning.Domain.Models.Test
{
    public static class TestDtoBuilder
    {

        public static TestDto CreateTest(string? name, List<QuestionDto> questions)
        {
            var testDto = new TestDto()
            {
                Name = name,
                Questions = questions
            };

            return testDto;
        }

        public static TestCountryDto CreateTestCountry(string? name, List<QuestionDto> questions, GuessType.Category category, List<ContinentDto> continents)
        {
            var testDto = new TestCountryDto()
            {
                Name = name,
                Questions = questions,
                Category = category,
                Continents = continents
            };

            return testDto;
        }
    }
}