using Application.Question.Queries.GetRandomQuestion;

namespace Web.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class QuestionController : ControllerBase
{

    private readonly IMediator _mediator;
    private readonly ILogger<QuestionController> _logger;

    public QuestionController(IMediator mediator, ILogger<QuestionController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost("generate")]
    public async Task<IActionResult> GenerateRandomQuestion(GetRandomQuestionQuery getRandomQuestionQuery)
    {
        var question = await _mediator.Send(getRandomQuestionQuery);

        return Ok(question);
    }
}
