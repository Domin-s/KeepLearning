using KeepLearning.Domain.Interfaces;
using MediatR;
using RestaurantAPI.Exceptions;

namespace KeepLearning.Domain.Queries.CheckAnswer
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
            var country = await _countryService.GetCountry(request.Question, request.Category);
            if (country == null)
            {
                throw new NotFoundException("Not found country");
            }

            var result = _countryService.IsCorrectAnswer(country, request.Answer, request.Category);

            return result;
        }
    }
}
