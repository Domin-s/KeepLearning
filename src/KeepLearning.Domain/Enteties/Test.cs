namespace KeepLearning.Domain.Enteties
{
    public class CountryTest : Test
    {
        public required string GuessType { get; set; }
        public required IEnumerable<Guid> ContinentIds { get; set; }
    }

    public class Test
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ExpiredAt { get; set; } = DateTime.Now.AddMinutes(60);
        public IEnumerable<Question> Questions { get; set; } = new List<Question>();
    }

}