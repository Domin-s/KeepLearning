
using Application.Common.Models.Question;
using Application.Question.Queries.GetRandomQuestion;

namespace Web.Endpoints
{
    public class Question : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {

        }

        public async Task<QuestionDto> GetRandomQuestion(ISender sender, [AsParameters] GetRandomQuestionQuery query)
        {
            return await sender.Send(query);
        }
    }
}