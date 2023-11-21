namespace KeepLearning.Domain.Enteties
{
    public class Test
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int NumberOfQuestion { get; set; } = 10;
        public DateTime CreatedAt { get; set; }
        public IEnumerable<Question> Questions { get; set; } = new List<Question>();
    }

}