using KeepLearning.Domain.Models.Enums;
using KeepLearning.Domain.Models.Question;
using KeepLearning.Domain.Interfaces;
using MediatR;

namespace KeepLearning.Domain.Queries.GetRandomQuestion
{
    public class GetRandomQuestionQueryHandler : IRequestHandler<GetRandomQuestionQuery, QuestionDto>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICountryService _countryService;

        public GetRandomQuestionQueryHandler(ICountryRepository countryRepository, ICountryService countryService)
        {
            _countryRepository = countryRepository;
            _countryService = countryService;
        }

        // TODO: Move getting random country to get random country in database ussing TSQL
        public async Task<QuestionDto> Handle(GetRandomQuestionQuery request, CancellationToken cancellationToken)
        {
            int numberOfQuestion = new Random().Next(0, 10);

            var continent = Continent.MapContinentToString(request.Continent);

            var countries = await _countryRepository.GetByContinent(continent);

            var randomCountry = _countryService.GetRandomCountry(countries.ListOfCountry);

            return QuestionHelper.FromCountryAndGuessType(randomCountry, request.GuessType, numberOfQuestion);
        }
    }
}
