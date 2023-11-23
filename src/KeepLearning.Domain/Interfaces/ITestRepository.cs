using KeepLearning.Domain.Enteties;

namespace KeepLearning.Domain.Interfaces
{
    public interface ITestRepository
    {
        public Task<Test> GetById(Guid testId);
        public Task<int> RemoveById(Guid testId);
        public Task<Test> Save(Test test);
    }
}