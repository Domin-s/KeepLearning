using KeepLearning.Domain.Models.Result.Test;
using KeepLearning.Domain.Interfaces;
using MediatR;
using KeepLearning.Domain.Models.Result;

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
            var numberOfCorrectAnswers = 0;
            var numberOfIncorrectAnswers = 0;


            foreach (var answer in request.Answers)
            {
                var correctAnswer = await _countryService.GetCorrectAnswer(answer.QuestionText, request.Category);

                if (answer.AnswerText is not null && answer.AnswerText?.ToLower() == correctAnswer.ToLower())
                {
                    numberOfCorrectAnswers++;
                }
                else
                {
                    numberOfIncorrectAnswers++;
                }
                answers.Add(new AnswerResultDto(answer.NumberOfQuestion, answer.AnswerText, correctAnswer));
            }

            var testResultDto = new TestResultDto(answers, numberOfCorrectAnswers, numberOfIncorrectAnswers);

            return testResultDto;
        }
    }
}
