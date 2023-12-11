using KeepLearning.Domain.Models;
using MediatR;

namespace KeepLearning.Application.Country.Queries.GetAllCountries
{
    public class GetAllCountriesQuery : IRequest<Countries>
    {
    }
}
