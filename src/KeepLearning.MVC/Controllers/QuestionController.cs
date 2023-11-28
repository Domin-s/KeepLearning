using KeepLearning.Domain.Queries.CheckAnswer;
using KeepLearning.Domain.Queries.GetAllContinents;
using KeepLearning.Domain.Queries.GetRandomQuestion;
using KeepLearning.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Create()
        {
            var continents = await _mediator.Send(new GetAllContinentsQuery());
            var questionDataViewModel = new QuestionDataViewModel(continents);

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
