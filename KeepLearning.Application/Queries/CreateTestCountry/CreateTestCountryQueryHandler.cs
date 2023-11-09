using KeepLearning.Domain.Models.Enums;
using KeepLearning.Domain.Models.Question;
using KeepLearning.Domain.Models.Test.Country;
using KeepLearning.Domain.Interfaces;
using MediatR;

namespace KeepLearning.Domain.Queries.CreateTestCountry
{
    public class CreateTestCountryQueryHandler : IRequestHandler<CreateTestCountryQuery, TestCountryDto>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICountryService _countryService;

        public CreateTestCountryQueryHandler(ICountryRepository countryRepository, ICountryService countryService)
        {
            _countryRepository = countryRepository;
            _countryService = countryService;
        }

        public async Task<TestCountryDto> Handle(CreateTestCountryQuery request, CancellationToken cancellationToken)
        {
            var mappedContinent = request.Continents.Select(c => Continent.MapContinentToString(c));

            var countries = await _countryRepository.GetByContinents(mappedContinent);

            var randomCountries = _countryService.GetRandomCountries(request.NumberOfQuestion);

            var questions = QuestionHelper.FromCountriesAndGuessType(randomCountries, request.GuessType);

            var test = new TestCountryDto(request, questions);

            return test;
        }
    }
}
