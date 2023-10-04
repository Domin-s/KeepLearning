using KeepLearning.Application.TestCountry.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KeepLearning.MVC.Controllers
{
    public class TestController : Controller
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }



        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestCountryCommand command)
        {
            var test = await _mediator.Send(command);

            return Ok(test.Questions);
        }

        public async Task<IActionResult> Details()
        {
            return View();
        }

    }
}
