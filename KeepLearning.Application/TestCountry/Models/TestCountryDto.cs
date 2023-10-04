namespace KeepLearning.Application.TestCountry.Models
{
    public class TestCountryDto : TestCountryBasic
    {
        public IEnumerable<Question> Questions { get; set; } = new List<Question>();
    }
}
