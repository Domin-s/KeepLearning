using KeepLearning.Application.Queries.GetCountries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KeepLearning.MVC.Controllers
{
    public class CountryController : Controller
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> List(GetCountriesQuery query)
        {
            var countries = await  _mediator.Send(query);

            return View(countries);
        }
    }
}
