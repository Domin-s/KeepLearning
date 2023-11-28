using KeepLearning.Domain.Models.Continent;
using MediatR;

namespace KeepLearning.Domain.Queries.GetAllContinents
{
    public class GetAllContinentsQuery : IRequest<IEnumerable<ContinentDto>>
    {
    }
}
