namespace KeepLearning.Domain.Enteties
{
    public class Question
    {
        public Guid Id { get; set; }
        public required int QuestionNumber { get; set; }
        public required string QuestionText { get; set; } = default!;
        public required string AnswerText { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ExpiredAt { get; set; } = DateTime.Now.AddMinutes(70);
        public Guid? TestId { get; set; }
        public Test? Test { get; set; }
    }
}