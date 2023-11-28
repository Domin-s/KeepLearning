using MediatR;

namespace KeepLearning.Domain.Queries.DownloadExam
{
    public class DownloadExamQueryHandler : IRequestHandler<DownloadExamQuery, string>
    {
        public Task<string> Handle(DownloadExamQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}