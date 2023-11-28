
using KeepLearning.Domain.Commands.CreateTestCountry;
using KeepLearning.Domain.Exceptions;
using KeepLearning.Domain.Models.Test.Country;
using KeepLearning.Domain.Queries.CheckTest;
using KeepLearning.Domain.Queries.GetAllContinents;
using KeepLearning.Domain.Queries.TestToDownload;
using KeepLearning.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KeepLearning.MVC.Controllers
{
    public class ExamController : Controller
    {
        const string SerializedExamCountry = "SerializedExamCountry";
        private readonly IMediator _mediator;

        public ExamController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet]
        public async Task<IActionResult> CreateTest()
        {
            var continents = await _mediator.Send(new GetAllContinentsQuery());
            var questionDataViewModel = new QuestionDataViewModel(continents);

            return View(questionDataViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTest(CreateTestCountryCommand command)
        {
            var test = await _mediator.Send(command);

            var serializedTest = JsonConvert.SerializeObject(test);
            TempData[SerializedExamCountry] = serializedTest;

            return RedirectToAction(nameof(Test));
        }

        public IActionResult Test()
        {
            var serializedTest = CheckTempData(SerializedExamCountry);

            var testCountryDto = JsonConvert.DeserializeObject<TestCountryDto>(serializedTest);

            TempData[SerializedExamCountry] = serializedTest;

            return View(testCountryDto);
        }

        [HttpPost]
        public async Task<IActionResult> CheckTest([FromForm] CheckTestQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        private string CheckTempData(string name)
        {
            var tempData = TempData[name];
            if (tempData is null)
            {
                throw new NotFoundException("TempData not found");
            }

            var serializedString = tempData.ToString();
            if (serializedString is null)
            {
                throw new Exception("TempData can not map to string");
            }

            return serializedString;
        }

        [HttpPost]
        public async Task<IActionResult> Download([FromForm] TestToDownloadQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}