using AutoMapper;
using KeepLearning.Domain.Exceptions;
using KeepLearning.Domain.Interfaces;
using KeepLearning.Domain.Models;
using KeepLearning.Domain.Models.Country;
using KeepLearning.Domain.Models.Question;
using MediatR;

namespace KeepLearning.Domain.Queries.GetRandomQuestion
{
    public class GetRandomQuestionQueryHandler : IRequestHandler<GetRandomQuestionQuery, QuestionDto>
    {
        private readonly IContinentRepository _continentRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public GetRandomQuestionQueryHandler(IContinentRepository continentRepository, ICountryRepository countryRepository, IMapper mapper)
        {
            _continentRepository = continentRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<QuestionDto> Handle(GetRandomQuestionQuery request, CancellationToken cancellationToken)
        {
            var continent = await _continentRepository.GetByName(request.Continent);
            if (continent is null)
            {
                throw new NotFoundException("Not found continent!");
            }

            var randomCountry = await _countryRepository.GetRandom(continent.Id);
            if (randomCountry is null)
            {
                throw new NotFoundException("Not found country");
            }

            var countryDto = _mapper.Map<CountryDto>(randomCountry);

            return QuestionDtoBuilder.CreateQuestionByCategory(countryDto, request.Category);
        }
    }
}
