using KeepLearning.Application.Common.Models.Continent;
using MediatR;

namespace KeepLearning.Application.Continent.Queries.GetAllContinents
{
    public class GetAllContinentsQuery : IRequest<IEnumerable<ContinentDto>>
    {
    }
}
