using Domain.Enteties;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class ExamRepository : IExamRepository
    {
        private readonly KeepLearningDbContext _dbContext;

        public ExamRepository(KeepLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Exam> Save(Exam exam)
        { 
            var result = await _dbContext.Exams.AddAsync(exam);
            _dbContext.SaveChanges();

            return result.Entity;
        }

        public async Task<Exam?> GetById(Guid examId)
            => await _dbContext.Exams.Where(exam => exam.Id == examId).FirstOrDefaultAsync();

        public async Task RemoveById(Guid examId)
        {
            var exam = await _dbContext.Exams.Where(exam => exam.Id == examId).FirstOrDefaultAsync();

            if (exam is null)
            {
                throw new NotFoundException($"Not found exam with id: {examId}");
            }

            var result = _dbContext.Exams.Remove(exam);
            _dbContext.SaveChanges();

        }
    }
}