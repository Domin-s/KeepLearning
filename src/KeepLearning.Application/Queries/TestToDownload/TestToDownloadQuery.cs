using KeepLearning.Domain.Models.Enums;
using KeepLearning.Domain.Models.Test.Country;
using MediatR;

namespace KeepLearning.Domain.Queries.TestToDownload
{
    public class TestToDownloadQuery : TestCountryDto, IRequest<string>
    {
        public FileType FileType { get; set; }

        public TestToDownloadQuery()
        {

        }
    }
}