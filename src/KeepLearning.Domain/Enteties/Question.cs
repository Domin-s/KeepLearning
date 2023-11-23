namespace KeepLearning.Domain.Enteties
{
    public class Question
    {
        public Guid Id { get; set; }
        public int QuestionNumber { get; set; }
        public string QuestionText { get; set; } = default!;
        public string AnswerText { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiredAt { get; set; }
        public Guid TestId { get; set; }
        public Test Test { get; set; }
    }
}