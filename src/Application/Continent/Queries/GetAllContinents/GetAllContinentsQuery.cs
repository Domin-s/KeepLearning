using Application.Common.Models.Continent;
using MediatR;

namespace Application.Continent.Queries.GetAllContinents
{
    public class GetAllContinentsQuery : IRequest<IEnumerable<ContinentDto>>
    {
    }
}
