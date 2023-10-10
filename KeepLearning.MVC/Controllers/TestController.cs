﻿using KeepLearning.Application.TestCountry.Models;
using KeepLearning.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KeepLearning.MVC.Controllers
{
    public class TestController : Controller
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Create()
        {
            var continents = Continent.GetAll();

            return View(continents);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestViewModel form)
        {
            var command = form.ToCreateTestCountryCommand();

            var test = await _mediator.Send(command);

            var questions = JsonConvert.SerializeObject(test.Questions);

            TempData["Questions"] = questions;

            return RedirectToAction(nameof(Resolve));
        }

        public IActionResult Resolve()
        {
            var jsonQuestion = TempData["Questions"].ToString();

            var questions = JsonConvert.DeserializeObject<IEnumerable<QuestionDto>>(jsonQuestion);

            return View(questions);
        }

    }
}
