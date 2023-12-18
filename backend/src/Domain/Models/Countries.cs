using Domain.Enteties;

namespace Domain.Models
{
    public record Countries(IEnumerable<Country> ListOfCountry)
    {
    }
}
