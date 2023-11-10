using KeepLearning.Domain.Models.Test.Country;
using KeepLearning.Domain.Queries.CheckAnswer;
using KeepLearning.Domain.Queries.CheckTest;
using KeepLearning.Domain.Queries.CreateTestCountry;
using KeepLearning.Domain.Queries.GetRandomQuestion;
using KeepLearning.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantAPI.Exceptions;

namespace KeepLearning.MVC.Controllers
{
    public class QuestionController : Controller
    {
        const string STDTestCountry = "SerializedTestCountry";

        private readonly IMediator _mediator;

        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var questionDataViewModel = new QuestionDataViewModel();

            return View(questionDataViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Random(GetRandomQuestionQuery getRandomQuestionQuery)
        {

            var question = await _mediator.Send(getRandomQuestionQuery);

            var modelView = new GuessRandomQuestionModelView(getRandomQuestionQuery, question);

            return View(modelView);
        }

        [HttpGet]
        public async Task<IActionResult> RandomAnotherQuestion(GetRandomQuestionQuery getRandomQuestionQuery)
        {

            var question = await _mediator.Send(getRandomQuestionQuery);

            return Ok(question);
        }

        [HttpGet]
        public async Task<IActionResult> CheckAnswer(CheckAnswerQuery checkAnswerQuery)
        {
            var result = await _mediator.Send(checkAnswerQuery);

            return Ok(result);
        }

        public IActionResult CreateTest()
        {
            var questionDataViewModel = new QuestionDataViewModel();

            return View(questionDataViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTest(CreateTestCountryQuery query)
        {
            var test = await _mediator.Send(query);

            var serializedTest = JsonConvert.SerializeObject(test);
            TempData[STDTestCountry] = serializedTest;

            return RedirectToAction(nameof(Test));
        }

        public IActionResult Test()
        {
            var serializedTest = CheckTempData(STDTestCountry);

            var testCountryDto = JsonConvert.DeserializeObject<TestCountryDto>(serializedTest);

            TempData[STDTestCountry] = serializedTest;

            return View(testCountryDto);
        }

        [HttpPost]
        public IActionResult CheckTest([FromForm]CheckTestQuery query)
        {

            Console.WriteLine("checkTestQuery");
            Console.WriteLine(query);

            return Ok(query);
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
    }
}
