using Application.Country.Queries.GetAllCountriesByContinents;
using Application.Country.Queries.GetNumberOfCountries;

namespace MVC.Controllers;

[ApiController]
[Route("[controller]")]
public class CountryController : ControllerBase
{

    private readonly IMediator _mediator;
    private readonly ILogger<CountryController> _logger;

    public CountryController(IMediator mediator, ILogger<CountryController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetCountriesByContinents([FromQuery]GetCountriesByContinentsQuery query)
    {
        var countries = await _mediator.Send(query);

        return Ok(countries);
    }

    [HttpGet("numberOfCountries")]
    public async Task<IActionResult> GetNumberOfCountries([FromQuery]GetNumberOfCountriesQuery query)
    {
        var numberOfCountries = await _mediator.Send(query);

        return Ok(numberOfCountries);
    }
}
