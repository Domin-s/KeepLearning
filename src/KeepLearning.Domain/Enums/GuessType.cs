using System.ComponentModel;

namespace KeepLearning.Domain.Models.Enums
{
    public static class GuessType
    {
        public enum Category
        {
            CapitalCity,
            Country
        }

        public static IEnumerable<string> GetAllLikeStrings()
            => Enum.GetValues(typeof(Category)).Cast<Category>().ToList().Select(c => c.ToString());

        public static string ToStringValue(Category category)
        {
            switch (category)
            {
                case Category.CapitalCity: return "Capital City";
                case Category.Country: return "Country";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
    }
}
