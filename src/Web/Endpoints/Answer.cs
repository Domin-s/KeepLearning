
using Application.Question.Queries.CheckAnswer;

namespace Web.Endpoints
{
    public class Answer : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
                .MapGet(IsCorrectAnswer, "isCorrect");
        }

        public async Task<bool> IsCorrectAnswer(ISender sender, [AsParameters] CheckAnswerQuery query)
        {
            return await sender.Send(query);
        }
    }
}