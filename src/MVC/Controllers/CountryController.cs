using Application.Continent.Queries.GetAllContinents;
using Application.Country.Queries.GetAllCountriesByContinents;
using Application.Country.Queries.GetNumberOfCountries;
using MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class CountryController : Controller
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List(GetAllCountriesByContinentsQuery query)
        {
            var countries = await _mediator.Send(query);
            var continents = await _mediator.Send(new GetAllContinentsQuery());

            var viewModel = new ListOfCountriesModelView(countries, continents);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GetNumberOfCountries(GetNumberOfCountriesQuery query)
        {
            var numberOfCountries = await _mediator.Send(query);

            return Ok(numberOfCountries);
        }
    }
}
