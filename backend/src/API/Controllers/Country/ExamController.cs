using Application.Exam.Queries.CheckExam;
using Application.Exam.Queries.GenerateExamCountry;
using Application.Exam.Queries.GetCategoryCountryExam;

namespace API.Controllers;

[ApiController]
[Route("api/country/[controller]")]
public class ExamController : ControllerBase
{

    private readonly IMediator _mediator;
    private readonly ILogger<ExamController> _logger;

    public ExamController(IMediator mediator, ILogger<ExamController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost("generate")]
    public async Task<IActionResult> GenerateExam(GenerateExamCountryQuery query)
    {
        var exam = await _mediator.Send(query);

        return Ok(exam);
    }

    [HttpPost("check")]
    public async Task<IActionResult> CheckExam(CheckExamQuery query)
    {
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("category")]
    public async Task<IActionResult> GetCategory()
    {
        var result = await _mediator.Send(new GetCategoryCountryExamQuery());

        return Ok(result);
    }
}
