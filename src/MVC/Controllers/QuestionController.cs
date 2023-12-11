using Application.Continent.Queries.GetAllContinents;
using Application.Question.Queries.CheckAnswer;
using Application.Question.Queries.GetRandomQuestion;
using MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class QuestionController : Controller
    {

        private readonly IMediator _mediator;

        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var continents = await _mediator.Send(new GetAllContinentsQuery());
            var questionDataViewModel = new QuestionDataViewModel(continents, new List<string>());

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
    }
}
