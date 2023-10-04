namespace KeepLearning.Application.TestCountry.Models
{
    public static class ContinentClass
    {
        public enum Continent
        {
            Africa,
            Asia,
            Australia,
            Europe,
            NorthAmerica,
            SouthAmerica
        };

        public static string ContinentString(Continent continent)
        {
            switch (continent)
            {
                case Continent.Africa: return "Africa";
                case Continent.Asia: return "Asia";
                case Continent.Australia: return "Australia";
                case Continent.Europe: return "Europe";
                case Continent.NorthAmerica: return "N. America";
                case Continent.SouthAmerica: return "S. America";

                default: throw new ArgumentException(message: "Invalid enum value");
            }
        }
    }
}