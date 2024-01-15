namespace Domain.Models.Enums;

public static class GuessType
{
    public enum Category
    {
        CapitalCity = 0,
        Country = 1
    }

    public static IEnumerable<Category> GetAllLikeStrings()
        => Enum.GetValues(typeof(Category)).Cast<Category>();
}
