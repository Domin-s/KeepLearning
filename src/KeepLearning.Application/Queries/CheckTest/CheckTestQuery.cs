using KeepLearning.Domain.Models.Answer;
using KeepLearning.Domain.Models.Enums;
using KeepLearning.Domain.Models.Result.Test;
using MediatR;

namespace KeepLearning.Domain.Queries.CheckTest
{
    public class CheckTestQuery : IRequest<TestResultDto>
    {
        public GuessType.Category GuessType { get; set; }
        public required IEnumerable<AnswerDto> Answers { get; set; }
    }
}
