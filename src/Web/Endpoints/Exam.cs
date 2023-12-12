using Application.Common.Models.Exam;
using Application.Common.Models.Exam.Country;
using Application.Exam.Queries.CheckExam;
using Application.Exam.Queries.GenerateExamCountry;

// TODO: KL-29: Check namespaces in queries and command

namespace Web.Endpoints
{
    public class Exam : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this);
            //.MapGet(GenerateExam, "generate")
            //.MapGet(CheckExam, "check");
        }

        public async Task<ExamCountryDto> GenerateExam(ISender sender, [AsParameters] GenerateExamCountryQuery command)
        {
            return await sender.Send(command);
        }

        public async Task<ExamResultDto> CheckExam(ISender sender, [AsParameters] CheckExamQuery query)
        {
            return await sender.Send(query);
        }
    }
}
