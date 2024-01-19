using Domain.Models.Enums;
using Infrastructure.Services;

namespace Application.Question.Queries.CheckAnswer;

public class CheckQuestionQueryHandler : IRequestHandler<CheckQuestionQuery, bool>
{
    private readonly CountryService _countryService;

    public CheckQuestionQueryHandler(CountryService countryService)
    {
        _countryService = countryService;
    }

    // TODO: Add validation to CheckQuestionQuery
    public async Task<bool> Handle(CheckQuestionQuery request, CancellationToken cancellationToken)
    {
        var category = GuessType.ToCategory(request.Category);

        var result = await _countryService.IsCorrectAnswer(request.Question, request.Answer, category);

        return result;
    }
}
