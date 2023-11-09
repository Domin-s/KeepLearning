using KeepLearning.Domain.Models.Enums;
using KeepLearning.Domain.Models.Test.Country;
using MediatR;

namespace KeepLearning.Domain.Queries.GetQuestions
{
    public class GetQuestionsQuery : IRequest<TestCountryDto>
    {
        public string? Name { get; set; }
        public int NumberOfQuestion { get; set; } = 10;
        public GuessType.Value GuessType { get; set; } = default!;
        public IEnumerable<Continent.Name> Continents { get; set; } = new List<Continent.Name>();
    }
}
