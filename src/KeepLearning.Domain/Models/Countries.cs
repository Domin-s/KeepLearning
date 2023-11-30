using KeepLearning.Domain.Enteties;

namespace KeepLearning.Domain.Models
{
    public record Countries(IEnumerable<Country> ListOfCountry)
    {
    }
}
