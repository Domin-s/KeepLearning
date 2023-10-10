using AutoMapper;
using KeepLearning.Application.Country;
using KeepLearning.Application.TestCountry.Models;
using KeepLearning.Domain.Interfaces;
using MediatR;

namespace KeepLearning.Application.TestCountry.Command
{
    internal class GetTestCountryCommandHandler : IRequestHandler<GetTestCountryCommand, TestCountryDto>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public GetTestCountryCommandHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<TestCountryDto> Handle(GetTestCountryCommand request, CancellationToken cancellationToken)
        {
            var mappedContinent = request.Continents.Select(c => Continent.MapContinentToString(c));

            var countries = await _countryRepository.GetByContinents(mappedContinent);

            var randomCountries = countries.GetRandomCountries(request.NumberOfQuestion);

            var questions = QuestionHandler.FromCountriesAndGuessType(randomCountries, request.GuessType);

            var test = CreateTest(request, questions);

            return test;
        }

        private TestCountryDto CreateTest(GetTestCountryCommand command, IEnumerable<QuestionDto> questions)
        {
            TestCountryDto test = new TestCountryDto()
            {
                Name = command.Name,
                NumberOfQuestion = command.NumberOfQuestion,
                Continents = command.Continents,
                Questions = questions,
            };

            return test;
        }
    }
}
