using Domain.Enteties;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class QuestionRepository : IQuestionRepository
    {
        private readonly KeepLearningDbContext _dbContext;

        public QuestionRepository(KeepLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Question>> GetByExamId(Guid examId)
            => await _dbContext.Questions.Where(q => q.ExamId == examId).ToListAsync();

        public async Task<Question?> GetById(Guid questionId)
            => await _dbContext.Questions.Where(q => q.Id == questionId).FirstOrDefaultAsync();

        public async Task RemoveByExamId(Guid examId)
        {
            var questions = await _dbContext.Questions.Where(q => q.ExamId == examId).ToListAsync();
            _dbContext.RemoveRange(questions);
        }

        public async Task RemoveById(Guid questionId)
        {
            var questions = await _dbContext.Questions.Where(q => q.Id == questionId).FirstOrDefaultAsync();
            if (questions is null)
            {
                throw new DirectoryNotFoundException($"Not found question with id {questionId}");
            }

            _dbContext.RemoveRange(questions);
        }

        public async Task<Question> Save(Question question)
        {
            var savedQuestion = await _dbContext.Questions.AddAsync(question);
            _dbContext.SaveChanges();

            return savedQuestion.Entity;
        }

        public async Task SaveMany(IEnumerable<Question> questions)
        {
            await _dbContext.Questions.AddRangeAsync(questions);
            _dbContext.SaveChanges();
        }
    }
}