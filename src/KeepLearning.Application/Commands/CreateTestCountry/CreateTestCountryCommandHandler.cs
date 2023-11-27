using AutoMapper;
using KeepLearning.Domain.Interfaces;
using KeepLearning.Domain.Enteties;
using KeepLearning.Domain.Models;
using KeepLearning.Domain.Models.Country;
using KeepLearning.Domain.Models.Test.Country;
using MediatR;
using KeepLearning.Domain.Models.Test;
using KeepLearning.Domain.Models.Continent;

namespace KeepLearning.Domain.Commands.CreateTestCountry
{
    public class CreateTestCountryCommandHandler : IRequestHandler<CreateTestCountryCommand, TestCountryDto>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CreateTestCountryCommandHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<TestCountryDto> Handle(CreateTestCountryCommand request, CancellationToken cancellationToken)
        {
            var continents = string.Join(",", request.Continents);
            var randomCountries = await _countryRepository.GetRandomCountries(continents, request.NumberOfQuestion);
            var countriesDto = randomCountries.Select(c => _mapper.Map<CountryDto>(c)).ToList();
            var continentsDto = request.Continents.Select(c => _mapper.Map<ContinentDto>(c)).ToList();

            var questionsDto = QuestionDtoBuilder.CreateQuestions(countriesDto, request);
            var testDto = TestDtoBuilder.CreateTestCountry(request.Name, questionsDto, request.Category, continentsDto);

            var test = _mapper.Map<Test>(testDto);

            return testDto;
        }
    }
}
