using KeepLearning.Application.Models.Result;
using MediatR;

namespace KeepLearning.Application.Queries.CheckTestQuery
{
    public class CheckTestQuery : IRequest<TestResultDto>
    {
    }
}
