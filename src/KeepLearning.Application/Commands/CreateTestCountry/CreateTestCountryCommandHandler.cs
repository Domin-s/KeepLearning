using KeepLearning.Domain.Models.Question;
using KeepLearning.Domain.Models.Test.Country;
using KeepLearning.Domain.Interfaces;
using MediatR;

namespace KeepLearning.Domain.Commands.CreateTestCountry
{
    public class CreateTestCountryCommandHandler : IRequestHandler<CreateTestCountryCommand, TestCountryDto>
    {
        private readonly ICountryRepository _countryRepository;

        public CreateTestCountryCommandHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<TestCountryDto> Handle(CreateTestCountryCommand request, CancellationToken cancellationToken)
        {
            var continents = string.Join(",", request.Continents);
            var randomCountries = await _countryRepository.GetRandomCountries(continents, request.NumberOfQuestion);

            var questions = QuestionHelper.FromCountriesAndGuessType(randomCountries, request.Category);

            var test = new TestCountryDto(request, questions);

            return test;
        }
    }
}
