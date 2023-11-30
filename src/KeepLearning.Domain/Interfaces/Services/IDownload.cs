using KeepLearning.Domain.Enteties;

namespace KeepLearning.Domain.Interfaces
{
    public interface IDownload
    {
        public string CreateFile(Exam test);
    }

}