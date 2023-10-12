using KeepLearning.Application.Models.Enums;
using KeepLearning.Application.Models.Question;
using KeepLearning.Domain.Interfaces;
using MediatR;

namespace KeepLearning.Application.Queries.GetRandomQuestion
{
    public class GetRandomQuestionQueryHandler : IRequestHandler<GetRandomQuestionQuery, QuestionDto>
    {
        private readonly ICountryRepository _countryRepository;

        public GetRandomQuestionQueryHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<QuestionDto> Handle(GetRandomQuestionQuery request, CancellationToken cancellationToken)
        {
            int numberOfQuestion = new Random().Next(0, 10);

            var continent = Continent.MapContinentToString(request.Continent);

            var countries = await _countryRepository.GetByContinent(continent);

            var randomCountry = countries.GetRandomCountry();

            return QuestionHandler.FromCountryAndGuessType(randomCountry, request.GuessType, numberOfQuestion);
        }
    }
}
