using KeepLearning.Domain.Models.Question;
using KeepLearning.Domain.Models.Test.Country;
using KeepLearning.Domain.Interfaces;
using MediatR;

namespace KeepLearning.Domain.Queries.CreateTestCountry
{
    public class CreateTestCountryQueryHandler : IRequestHandler<CreateTestCountryQuery, TestCountryDto>
    {
        private readonly ICountryService _countryService;

        public CreateTestCountryQueryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<TestCountryDto> Handle(CreateTestCountryQuery request, CancellationToken cancellationToken)
        {
            var randomCountries = await _countryService.GetRandomCountries(request.Continents, request.NumberOfQuestion);

            var questions = QuestionHelper.FromCountriesAndGuessType(randomCountries, request.Category);

            var test = new TestCountryDto(request, questions);

            return test;
        }
    }
}
