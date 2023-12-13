using Application.Common.Models.Exam.Country;
using Application.Continent.Queries.GetAllContinents;
using Application.Exam.Queries.CheckExam;
using Application.Exam.Queries.GenerateExamCountry;

namespace MVC.Controllers;

public class ExamController : ControllerBase
{

    private readonly IMediator _mediator;
    private readonly ILogger<ExamController> _logger;

    public ExamController(IMediator mediator, ILogger<ExamController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("generate")]
    public async Task<IActionResult> GenerateExam(GenerateExamCountryQuery query)
    {
        var exam = await _mediator.Send(query);

        return Ok(exam);
    }

    [HttpGet("check")]
    public async Task<IActionResult> CheckExam(CheckExamQuery query)
    {
        var result = await _mediator.Send(query);

        return Ok(result);
    }
}
