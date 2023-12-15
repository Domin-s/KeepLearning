using System.ComponentModel;

namespace Domain.Models.Enums;

public static class GuessType
{
    public enum Category
    {
        CapitalCity,
        Country
    }

    public static IEnumerable<string> GetAllLikeStrings()
        => Enum.GetValues(typeof(Category)).Cast<Category>().ToList().Select(c => ToStringValue(c));

    public static string ToStringValue(Category category)
    {
        switch (category)
        {
            case Category.CapitalCity: return "Capital city";
            case Category.Country: return "Country";
            default:
                throw new InvalidEnumArgumentException();
        }
    }
}
