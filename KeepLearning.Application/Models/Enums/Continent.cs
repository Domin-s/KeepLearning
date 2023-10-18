namespace KeepLearning.Application.Models.Enums
{
    public static class Continent
    {
        public enum Name
        {
            Africa,
            Asia,
            Australia,
            Europe,
            NorthAmerica,
            SouthAmerica
        };

        // TODO: Add test for this!
        public static string MapContinentToString(Name continent)
        {
            switch (continent)
            {
                case Name.Africa: return "Africa";
                case Name.Asia: return "Asia";
                case Name.Australia: return "Australia";
                case Name.Europe: return "Europe";
                case Name.NorthAmerica: return "N. America";
                case Name.SouthAmerica: return "S. America";

                default: throw new ArgumentException(message: "Invalid enum value");
            }
        }

        // TODO: Add test for this!
        public static Name MapStringToContinent(string continent)
        {
            switch (continent)
            {
                case "Africa": return Name.Africa;
                case "Asia": return Name.Asia;
                case "Australia": return Name.Australia;
                case "Europe": return Name.Europe;
                case "N. America": return Name.NorthAmerica;
                case "S. America": return Name.SouthAmerica;

                default: throw new ArgumentException(message: "Invalid enum value");
            }
        }

        public static IEnumerable<string> GetAllLikeStrings()
            => Enum.GetValues(typeof(Name)).Cast<Name>().ToList().Select(n => MapContinentToString(n));

    }
}