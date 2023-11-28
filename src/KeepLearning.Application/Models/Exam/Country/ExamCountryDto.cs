using KeepLearning.Domain.Models.Continent;
using static KeepLearning.Domain.Models.Enums.GuessType;

namespace KeepLearning.Domain.Models.Exam.Country
{
    public class ExamCountryDto : ExamDto
    {
        public required Category Category { get; set; }
        public IEnumerable<ContinentDto> Continents { get; set; } = new List<ContinentDto>();
    }
}
