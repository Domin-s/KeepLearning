using KeepLearning.Application.Models.Enums;
using KeepLearning.Application.Queries.Question;
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
        public IActionResult Create()
        {
            var continents = Continent.GetAllLikeStrings();
            var guessTypes = GuessType.GetAllLikeStrings();

            var randomQuestionViewModel = new RandomQuestionViewModel(continents, guessTypes);

            return View(randomQuestionViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Random(GetRandomQuestionQuery getRandomQuestionQuery)
        {

            var question = await _mediator.Send(getRandomQuestionQuery);

            var modelView = new GuessRandomQuestionModelView(getRandomQuestionQuery, question);

            return View(modelView);
        }
    }
}
