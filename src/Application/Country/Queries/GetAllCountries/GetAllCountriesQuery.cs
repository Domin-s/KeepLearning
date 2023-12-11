using Domain.Models;
using MediatR;

namespace Application.Country.Queries.GetAllCountries
{
    public class GetAllCountriesQuery : IRequest<Countries>
    {
    }
}
