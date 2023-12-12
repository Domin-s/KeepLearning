using Application.Common.Models.Continent;
using Application.Continent.Queries.GetAllContinents;

namespace Web.Endpoints
{
    public class Continentn : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
                .MapGet(GetAllContinents);
        }

        public async Task<IEnumerable<ContinentDto>> GetAllContinents(ISender sender)
        {
            return await sender.Send(new GetAllContinentsQuery());
        }
    }
}