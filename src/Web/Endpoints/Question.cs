
using Application.Common.Models.Question;
using Application.Question.Queries.GetRandomQuestion;

namespace Web.Endpoints
{
    public class Question : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this);
            //.MapGet(GenerateQuestion, "generate");
        }

        // TODO: change GetRandomQuestionQuery to GenerateQuestion
        public async Task<QuestionDto> GenerateQuestion(ISender sender, [AsParameters] GetRandomQuestionQuery query)
        {
            return await sender.Send(query);
        }
    }
}