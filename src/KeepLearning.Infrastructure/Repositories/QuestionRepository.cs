using KeepLearning.Domain.Enteties;
using KeepLearning.Domain.Interfaces.Repositories;
using KeepLearning.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace KeepLearning.Infrastructure.Repositories
{
    internal class QuestionRepository : IQuestionRepository
    {
        private readonly KeepLearningDbContext _dbContext;

        public QuestionRepository(KeepLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Question?> GetById(Guid questionId)
            => await _dbContext.Questions.FromSqlRaw($"Exec GetQuestionById @Id = {questionId}").FirstAsync();

        public async Task<IEnumerable<Question>> GetByTestId(Guid testId)
            => await _dbContext.Questions.FromSqlRaw($"Exec GetQuestionByTestId @{testId}").ToListAsync();

        public async Task<int> RemoveById(Guid questionId)
            => await _dbContext.Questions.FromSqlRaw($"Exec RemoveById @Id = @{questionId}").ExecuteDeleteAsync();

        public async Task<int> RemoveByTestId(Guid testId)
            => await _dbContext.Questions.FromSqlRaw($"Exec RemoveByTestId @{testId}").ExecuteDeleteAsync();

        public async Task<Question> Save(Question question)
            => await _dbContext.Questions.FromSqlRaw("Exec SaveQuestion ").FirstAsync();

        public async Task<IEnumerable<Question>> SaveMany(IEnumerable<Question> questions)
            => await _dbContext.Questions.FromSqlRaw("Exec SaveQuestions").ToListAsync();
    }
}