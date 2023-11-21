namespace KeepLearning.Domain.Enteties
{
    public class Test
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int NumberOfQuestions { get; set; } = 10;
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiredAt { get; set; }
        public IEnumerable<Question> Questions { get; set; } = new List<Question>();
    }

}