using KeepLearning.Domain.Models.Enums;
using KeepLearning.Domain.Models.Exam.Country;
using MediatR;

namespace KeepLearning.Domain.Commands.CreateExamCountry
{
    public class CreateExamCountryCommand : IRequest<ExamCountryDto>
    {
        public string? Name { get; set; }
        public int NumberOfQuestion { get; set; } = 10;
        public GuessType.Category Category { get; set; } = default!;
        public List<string> Continents { get; set; } = new List<string>();
    }
}
