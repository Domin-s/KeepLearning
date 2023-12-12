using Application.Common.Models.Continent;
using static Domain.Models.Enums.GuessType;

namespace Application.Common.Models.Exam.Country;

public class ExamCountryDto : ExamDto
{
    public required Category Category { get; set; }
    public IEnumerable<ContinentDto> Continents { get; set; } = new List<ContinentDto>();
}
