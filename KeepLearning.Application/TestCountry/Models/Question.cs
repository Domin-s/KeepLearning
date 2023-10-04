namespace KeepLearning.Application.TestCountry.Models
{
    public class Question
    {
        public string CountryName { get; set; } = default!;
        public string CountryCapitalCity { get; set; } = default!;
        public ToGuessType ToGuessType { get; set; }
    }
}
