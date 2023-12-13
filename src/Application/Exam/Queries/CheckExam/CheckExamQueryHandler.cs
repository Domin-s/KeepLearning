using Application.Common.Models.Answer;
using Application.Common.Models.Exam;
using Infrastructure.Services;

namespace Application.Exam.Queries.CheckExam;

public class CheckExamQueryHandler : IRequestHandler<CheckExamQuery, ExamResultDto>
{
    private readonly CountryService _countryService;

    public CheckExamQueryHandler(CountryService countryService)
    {
        _countryService = countryService;
    }

    // TODO: Refactor to use one method for all questions - easier to test in future
    public async Task<ExamResultDto> Handle(CheckExamQuery request, CancellationToken cancellationToken)
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

        var examResultDto = new ExamResultDto(answers, numberOfCorrectAnswers, numberOfIncorrectAnswers);

        return examResultDto;
    }
}
