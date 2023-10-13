using KeepLearning.Application.Models.Enums;
using KeepLearning.Application.Models.Question;
using KeepLearning.Application.Models.TestCountry;
using KeepLearning.Application.Queries.CheckAnswer;
using KeepLearning.Application.Queries.GetQuestionsQuery;
using KeepLearning.Application.Queries.GetRandomQuestion;
using KeepLearning.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            var questionDataViewModel = CreateQuestionDataViewModel();

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
            var questionDataViewModel = CreateQuestionDataViewModel();

            return View(questionDataViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTest(GetQuestionsQuery query)
        {
            var test = await _mediator.Send(query);

            var serializedTest = JsonConvert.SerializeObject(test);
            TempData[STDTestCountry] = serializedTest;

            return RedirectToAction(nameof(Test));
        }

        public IActionResult Test()
        {
            var serializedTest = CheckTempData(STDTestCountry);

            var questions = JsonConvert.DeserializeObject<TestCountryDto>(serializedTest);

            return View(questions);
        }
        private string CheckTempData(string name)
        {
            var tempData = TempData[name];
            if (tempData is null)
            {
                throw new Exception("Something wont wrong");
            }

            var serializedTest = tempData.ToString();
            if (serializedTest is null)
            {
                throw new Exception("Something wont wrong");
            }

            return serializedTest;
        }

        private QuestionDataViewModel CreateQuestionDataViewModel()
        {
            var continents = Continent.GetAllLikeStrings();
            var guessTypes = GuessType.GetAllLikeStrings();

            return new QuestionDataViewModel(continents, guessTypes);
        }
    }
}
