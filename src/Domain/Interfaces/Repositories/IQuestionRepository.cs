using Domain.Enteties;

namespace Domain.Interfaces.Repositories
{
    public interface IQuestionRepository
    {
        public Task<Question?> GetById(Guid questionId);
        public Task<IEnumerable<Question>> GetByExamId(Guid examId);
        public Task RemoveById(Guid questionId);
        public Task RemoveByExamId(Guid examId);
        public Task<Question> Save(Question question);
        public Task SaveMany(IEnumerable<Question> questions);
    }
}