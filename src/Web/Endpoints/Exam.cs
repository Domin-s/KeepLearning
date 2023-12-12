
using Application.Common.Models.Exam;
using Application.Common.Models.Result.Exam;
using Application.Exam.Queries.CheckExam;
// TODO: KL-29: Check namespaces in queries and command
using Domain.Commands.CreateExamCountry;

namespace Web.Endpoints
{
    public class Exam : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            throw new NotImplementedException();
        }

        public async Task<ExamDto> CreateExam(ISender sender, [AsParameters] CreateExamCountryCommand command)
        {
            return await sender.Send(command);
        }

        public async Task<ExamResultDto> CheckExam(ISender sender, [AsParameters] CheckExamQuery query)
        {
            return await sender.Send(query);
        }
    }
}