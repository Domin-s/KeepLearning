using Infrastructure.Services;

namespace Application.Question.Queries.CheckAnswer;

public class CheckAnswerQueryHandler : IRequestHandler<CheckAnswerQuery, bool>
{
    private readonly CountryService _countryService;

    public CheckAnswerQueryHandler(CountryService countryService)
    {
        _countryService = countryService;
    }

    public async Task<bool> Handle(CheckAnswerQuery request, CancellationToken cancellationToken)
    {
        var result = await _countryService.IsCorrectAnswer(request.Question, request.Answer, request.Category);

        return result;
    }
}
