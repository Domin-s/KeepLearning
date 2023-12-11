using AutoMapper;
using Application.Common.Models.Country;
using Application.Common.Models.Question;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Question.Queries.GetRandomQuestion
{
    public class GetRandomQuestionQueryHandler : IRequestHandler<GetRandomQuestionQuery, QuestionDto>
    {
        private readonly IContinentRepository _continentRepository;
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public GetRandomQuestionQueryHandler(IContinentRepository continentRepository, ICountryService countryService, IMapper mapper)
        {
            _continentRepository = continentRepository;
            _countryService = countryService;
            _mapper = mapper;
        }

        public async Task<QuestionDto> Handle(GetRandomQuestionQuery request, CancellationToken cancellationToken)
        {
            var continent = await _continentRepository.GetByName(request.Continent);
            if (continent is null)
            {
                throw new NotFoundException("Not found continent!");
            }

            var randomCountry = await _countryService.GetRandom(continent.Id);
            if (randomCountry is null)
            {
                throw new NotFoundException("Not found country");
            }

            var countryDto = _mapper.Map<CountryDto>(randomCountry);

            return QuestionDtoBuilder.CreateQuestionByCategory(countryDto, request.Category);
        }
    }
}
