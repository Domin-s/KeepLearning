using KeepLearning.Application.Common.Models.Exam.Country;
using KeepLearning.Domain.Models.Enums;
using MediatR;

namespace KeepLearning.Application.Exam.Queries.DownloadExam
{
    public class DownloadExamQuery : ExamCountryDto, IRequest<string>
    {
        public FileType FileType { get; set; }

        public DownloadExamQuery()
        {

        }
    }
}