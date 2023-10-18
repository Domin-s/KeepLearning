using KeepLearning.Application.Models.Enums;
using KeepLearning.Application.Models.Question;
using KeepLearning.Application.Models.TestCountry;
using KeepLearning.Domain.Interfaces;
using MediatR;

namespace KeepLearning.Application.Queries.GetQuestionsQuery
{
    public class GetQuestionsQueryHandler : IRequestHandler<GetQuestionsQuery, TestCountryDto>
    {
        private readonly ICountryRepository _countryRepository;

        public GetQuestionsQueryHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<TestCountryDto> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
        {
            var mappedContinent = request.Continents.Select(c => Continent.MapContinentToString(c));

            var countries = await _countryRepository.GetByContinents(mappedContinent);

            var randomCountries = countries.GetRandomCountries(request.NumberOfQuestion);

            var questions = QuestionHandler.FromCountriesAndGuessType(randomCountries, request.GuessType);

            var test = CreateTest(request, questions);

            return test;
        }

        private TestCountryDto CreateTest(GetQuestionsQuery command, IEnumerable<QuestionDto> questions)
        {
            TestCountryDto test = new TestCountryDto()
            {
                Name = command.Name,
                NumberOfQuestion = command.NumberOfQuestion,
                Continents = command.Continents,
                Questions = questions,
                GuessType = command.GuessType
            };

            return test;
        }
    }
}
