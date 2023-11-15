using KeepLearning.Domain.Models.Result.Test;
using KeepLearning.Domain.Interfaces;
using MediatR;
using KeepLearning.Domain.Models.Result;
using RestaurantAPI.Exceptions;

namespace KeepLearning.Domain.Queries.CheckTest
{
    public class CheckTestQueryHandler : IRequestHandler<CheckTestQuery, TestResultDto>
    {
        private readonly ICountryService _countryService;

        public CheckTestQueryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<TestResultDto> Handle(CheckTestQuery request, CancellationToken cancellationToken)
        {
            var answers = new List<AnswerResultDto>();
            var goodAnswers = 0;
            var badAnswers = 0;


            foreach (var answer in request.Answers)
            {
                var correctAnswer = await _countryService.GetCorrectAnswer(answer.QuestionText, request.GuessType);

                if (answer.AnswerText == correctAnswer)
                {
                    goodAnswers++;
                } else
                {
                    badAnswers++;
                }
                answers.Add(new AnswerResultDto(answer.NumberOfQuestion, answer.AnswerText, correctAnswer));
            }

            var testResultDto = new TestResultDto(answers, goodAnswers, badAnswers);

            return testResultDto;
        }
    }
}
