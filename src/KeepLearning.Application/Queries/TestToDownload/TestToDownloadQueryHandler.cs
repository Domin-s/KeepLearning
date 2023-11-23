using MediatR;

namespace KeepLearning.Domain.Queries.TestToDownload
{
    public class TestToDownloadQueryHandler : IRequestHandler<TestToDownloadQuery, string>
    {
        public Task<string> Handle(TestToDownloadQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}