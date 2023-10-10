using KeepLearning.Application.Models.Enums;
using KeepLearning.Application.Models.Question;
using KeepLearning.Domain.Interfaces;
using MediatR;

namespace KeepLearning.Application.Queries.Question
{
    public class GetQuestionQueryHandler : IRequestHandler<GetQuestionQuery, QuestionDto>
    {
        private readonly ICountryRepository _countryRepository;

        public GetQuestionQueryHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<QuestionDto> Handle(GetQuestionQuery request, CancellationToken cancellationToken)
        {
            var continent = Continent.MapContinentToString(request.Continent);

            var countries = await _countryRepository.GetByContinent(continent);

            var randomCountry = countries.GetRandomCountry();

            return QuestionHandler.FromCountryAndGuessType(randomCountry, request.GuessType);
        }
    }
}
