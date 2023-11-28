using AutoMapper;
using KeepLearning.Domain.Interfaces;
using KeepLearning.Domain.Enteties;
using KeepLearning.Domain.Models;
using KeepLearning.Domain.Models.Country;
using KeepLearning.Domain.Models.Test.Country;
using MediatR;
using KeepLearning.Domain.Models.Test;
using KeepLearning.Domain.Models.Continent;
using KeepLearning.Domain.Exceptions;

namespace KeepLearning.Domain.Commands.CreateTestCountry
{
    public class CreateTestCountryCommandHandler : IRequestHandler<CreateTestCountryCommand, TestCountryDto>
    {
        private readonly IContinentRepository _continentRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CreateTestCountryCommandHandler(IContinentRepository continentRepository, ICountryRepository countryRepository, IMapper mapper)
        {
            _continentRepository = continentRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<TestCountryDto> Handle(CreateTestCountryCommand request, CancellationToken cancellationToken)
        {
            var continents = await _continentRepository.GetByNames(request.Continents);
            if (!continents.Any())
            {
                throw new NotFoundException("Not found any continents");
            }

            var continentIds = continents.Select(c => c.Id);
            var randomCountries = await _countryRepository.GetRandomCountries(continentIds, request.NumberOfQuestion);
            if (!randomCountries.Any())
            {
                throw new NotFoundException("Not found any country for these continents");
            }

            var countriesDto = randomCountries.Select(c => _mapper.Map<CountryDto>(c)).ToList();
            var continentsDto = request.Continents.Select(c => _mapper.Map<ContinentDto>(c)).ToList();

            var questionsDto = QuestionDtoBuilder.CreateQuestions(countriesDto, request);
            var testDto = TestDtoBuilder.CreateTestCountry(request.Name, questionsDto, request.Category, continentsDto);

            return testDto;
        }
    }
}
