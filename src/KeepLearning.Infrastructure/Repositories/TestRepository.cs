using KeepLearning.Domain.Enteties;
using KeepLearning.Domain.Interfaces;
using KeepLearning.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace KeepLearning.Infrastructure.Repositories
{
    internal class TestRepository : ITestRepository
    {
        private readonly KeepLearningDbContext _dbContext;

        public TestRepository(KeepLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // public async Task<Test> Save(Test test)
        //     => await _dbContext.Tests.FromSqlRaw($"Exec SaveTest {test}").FirstAsync();

        // public async Task<Test> GetById(Guid testId)
        //     => await _dbContext.Tests.FromSqlRaw($"Exec GetTestById @Id = {testId}").FirstAsync();

        // public async Task<int> RemoveById(Guid testId)
        //     => await _dbContext.Tests.FromSqlRaw($"Exec RemoveTestById @Id = {testId}").ExecuteDeleteAsync();
    }
}