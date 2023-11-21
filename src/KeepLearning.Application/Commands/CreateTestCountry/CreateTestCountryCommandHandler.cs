using KeepLearning.Domain.Models.Question;
using KeepLearning.Domain.Models.Test.Country;
using KeepLearning.Domain.Interfaces;
using MediatR;

namespace KeepLearning.Domain.Commands.CreateTestCountry
{
    public class CreateTestCountryCommandHandler : IRequestHandler<CreateTestCountryCommand, TestCountryDto>
    {
        private readonly ICountryService _countryService;

        public CreateTestCountryCommandHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<TestCountryDto> Handle(CreateTestCountryCommand request, CancellationToken cancellationToken)
        {
            var randomCountries = await _countryService.GetRandomCountries(request.Continents, request.NumberOfQuestion);

            var questions = QuestionHelper.FromCountriesAndGuessType(randomCountries, request.Category);

            var test = new TestCountryDto(request, questions);

            return test;
        }
    }
}
