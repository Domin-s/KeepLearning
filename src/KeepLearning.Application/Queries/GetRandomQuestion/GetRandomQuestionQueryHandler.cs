using AutoMapper;
using KeepLearning.Domain.Interfaces;
using KeepLearning.Domain.Models;
using KeepLearning.Domain.Models.Country;
using KeepLearning.Domain.Models.Question;
using MediatR;
using RestaurantAPI.Exceptions;

namespace KeepLearning.Domain.Queries.GetRandomQuestion
{
    public class GetRandomQuestionQueryHandler : IRequestHandler<GetRandomQuestionQuery, QuestionDto>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public GetRandomQuestionQueryHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<QuestionDto> Handle(GetRandomQuestionQuery request, CancellationToken cancellationToken)
        {
            var randomCountry = await _countryRepository.GetRandom(request.Continent.Name);
            if (randomCountry is null)
            {
                throw new NotFoundException("Not found country");
            }

            var countryDto = _mapper.Map<CountryDto>(randomCountry);

            return QuestionDtoBuilder.CreateQuestionByCategory(countryDto, request.Category);
        }
    }
}
