using static KeepLearning.Application.Models.Enums.Continent;

namespace KeepLearning.Application.Models.Enums
{
    public static class GuessType
    {
        public enum Value
        {
            CapitalCity,
            Country
        }

        public static IEnumerable<string> GetAllLikeStrings()
            => Enum.GetValues(typeof(Value)).Cast<Value>().ToList().Select(c => c.ToString());

    }
}
