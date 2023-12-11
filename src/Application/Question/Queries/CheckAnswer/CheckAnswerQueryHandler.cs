using Domain.Interfaces;
using MediatR;

namespace Application.Question.Queries.CheckAnswer
{
    public class CheckAnswerQueryHandler : IRequestHandler<CheckAnswerQuery, bool>
    {
        private readonly ICountryService _countryService;

        public CheckAnswerQueryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<bool> Handle(CheckAnswerQuery request, CancellationToken cancellationToken)
        {
            var result = await _countryService.IsCorrectAnswer(request.Question, request.Answer, request.Category);

            return result;
        }
    }
}
