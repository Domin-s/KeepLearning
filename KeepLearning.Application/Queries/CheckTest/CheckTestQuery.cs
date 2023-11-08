using KeepLearning.Application.Models.Answer;
using KeepLearning.Application.Models.Enums;
using KeepLearning.Application.Models.Result.Test;
using MediatR;

namespace KeepLearning.Application.Queries.CheckTest
{
    public class CheckTestQuery : IRequest<TestResultDto>
    {
        public GuessType.Value GuessType { get; set; }
        public required IEnumerable<AnswerDto> Answers { get; set; }
    }
}
