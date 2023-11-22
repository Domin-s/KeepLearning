using KeepLearning.Domain.Models;
using MediatR;

namespace KeepLearning.Domain.Queries.GetAllCountries
{
    public class GetAllCountriesQuery : IRequest<Countries>
    {
    }
}
