using Application.Common.Models.Exam.Country;
using Domain.Models.Enums;
using MediatR;

namespace Application.Exam.Queries.DownloadExam
{
    public class DownloadExamQuery : ExamCountryDto, IRequest<string>
    {
        public FileType FileType { get; set; }

        public DownloadExamQuery()
        {

        }
    }
}