using KeepLearning.Domain.Models.Enums;
using KeepLearning.Domain.Models.Question;
using KeepLearning.Domain.Interfaces;
using MediatR;

namespace KeepLearning.Domain.Queries.GetRandomQuestion
{
    public class GetRandomQuestionQueryHandler : IRequestHandler<GetRandomQuestionQuery, QuestionDto>
    {
        private readonly ICountryService _countryService;

        public GetRandomQuestionQueryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        // TODO: Move getting random country to get random country in database ussing TSQL
        public async Task<QuestionDto> Handle(GetRandomQuestionQuery request, CancellationToken cancellationToken)
        {
            int numberOfQuestion = new Random().Next(0, 10);

            var continetByList = new List<Continent.Name>() { request.Continent };

            var randomCountry = await _countryService.GetRandomCountry(continetByList);

            return QuestionHelper.FromCountryAndGuessType(randomCountry, request.Category, numberOfQuestion);
        }
    }
}
