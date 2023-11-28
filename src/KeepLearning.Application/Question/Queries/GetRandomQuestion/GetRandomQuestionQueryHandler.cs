using AutoMapper;
using KeepLearning.Application.Common.Models.Country;
using KeepLearning.Application.Common.Models.Question;
using KeepLearning.Domain.Exceptions;
using KeepLearning.Domain.Interfaces;
using MediatR;

namespace KeepLearning.Application.Question.Queries.GetRandomQuestion
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
