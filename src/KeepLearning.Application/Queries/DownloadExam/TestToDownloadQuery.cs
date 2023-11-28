using KeepLearning.Domain.Models.Enums;
using KeepLearning.Domain.Models.Exam.Country;
using MediatR;

namespace KeepLearning.Domain.Queries.DownloadExam
{
    public class DownloadExamQuery : ExamCountryDto, IRequest<string>
    {
        public FileType FileType { get; set; }

        public DownloadExamQuery()
        {

        }
    }
}