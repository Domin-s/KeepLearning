using KeepLearning.Domain.Models.Enums;
using KeepLearning.Domain.Models.Question;
using KeepLearning.Domain.Interfaces;
using MediatR;
using RestaurantAPI.Exceptions;

namespace KeepLearning.Domain.Queries.GetRandomQuestion
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
            var continent = Continent.MapContinentToString(request.Continent);
            var randomCountry = await _countryRepository.GetRandom(continent);

            if (randomCountry is null)
            {
                throw new NotFoundException("Not found country");
            }

            return QuestionHelper.FromCountryAndGuessType(randomCountry, request.Category);
        }
    }
}
