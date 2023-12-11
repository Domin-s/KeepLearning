using Application.Common.Models.Exam.Country;
using Domain.Models.Enums;
using MediatR;

namespace Domain.Commands.CreateExamCountry
{
    public class CreateExamCountryCommand : IRequest<ExamCountryDto>
    {
        public string? Name { get; set; }
        public int NumberOfQuestion { get; set; } = 10;
        public GuessType.Category Category { get; set; } = default!;
        public List<string> Continents { get; set; } = new List<string>();
    }
}
