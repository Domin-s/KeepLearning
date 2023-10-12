using KeepLearning.Application.Models.Enums;
using KeepLearning.Application.Models.Question;
using KeepLearning.Application.Queries.CheckAnswer;
using KeepLearning.Application.Queries.GetRandomQuestion;
using KeepLearning.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KeepLearning.MVC.Controllers
{
    public class QuestionController : Controller
    {
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
        public async Task<IActionResult> CreateTest(CreateQuestionsViewModel form)
        {
            var command = form.ToCreateTestCountryCommand();

            var test = await _mediator.Send(command);

            var questions = JsonConvert.SerializeObject(test.Questions);

            TempData["Questions"] = questions;

            return RedirectToAction(nameof(Resolve));
        }

        public IActionResult Resolve()
        {
            string jsonQuestion = TempData["Questions"].ToString();

            var questions = JsonConvert.DeserializeObject<IEnumerable<QuestionDto>>(jsonQuestion);

            return View(questions);
        }

        private QuestionDataViewModel CreateQuestionDataViewModel()
        {
            var continents = Continent.GetAllLikeStrings();
            var guessTypes = GuessType.GetAllLikeStrings();

            return new QuestionDataViewModel(continents, guessTypes);
        }
    }
}
