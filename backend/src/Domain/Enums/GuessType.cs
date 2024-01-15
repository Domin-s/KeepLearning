namespace Domain.Models.Enums;

public static class GuessType
{
    public enum Category
    {
        CapitalCity,
        Country
    }

    public static IEnumerable<string> GetAllLikeStrings()
        => Enum.GetValues(typeof(Category)).Cast<Category>().ToList().Select(GuessType.ToString);

    public static string ToString(GuessType.Category category)
    {
        switch (category)
        {
            case Category.CapitalCity: return "Capital City";
            case Category.Country: return "Country";
            default: return "Country";
        }
    }

    public static Category ToCategory(string category)
    {
        switch (category)
        {
            case "Capital City": return Category.CapitalCity;
            case "Country": return Category.Country;
            default: return Category.Country;
        }
    }
}
