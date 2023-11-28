using KeepLearning.Application.Common.Models.Continent;
using KeepLearning.Application.Common.Models.Exam;
using static KeepLearning.Domain.Models.Enums.GuessType;

namespace KeepLearning.Application.Common.Models.Exam.Country
{
    public class ExamCountryDto : ExamDto
    {
        public required Category Category { get; set; }
        public IEnumerable<ContinentDto> Continents { get; set; } = new List<ContinentDto>();
    }
}
