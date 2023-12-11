namespace Domain.Enteties
{
    public class Exam
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ExpiredAt { get; set; } = DateTime.Now.AddMinutes(60);
        public IEnumerable<Question> Questions { get; set; } = new List<Question>();
        public string? ExtraInformations { get; set; }
    }

}