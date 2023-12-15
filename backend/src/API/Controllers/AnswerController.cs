using Application.Question.Queries.CheckAnswer;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnswerController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger<AnswerController> _logger;

        public AnswerController(IMediator mediator, ILogger<AnswerController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("check")]
        public async Task<IActionResult> CheckAnswer(CheckAnswerQuery checkAnswerQuery)
        {
            var result = await _mediator.Send(checkAnswerQuery);

            return Ok(result);
        }
    }
}
