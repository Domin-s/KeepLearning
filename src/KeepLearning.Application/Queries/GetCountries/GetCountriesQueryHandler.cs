using AutoMapper;
using KeepLearning.Domain.Interfaces;
using KeepLearning.Domain.Models;
using KeepLearning.Domain.Models.Enums;
using MediatR;

namespace KeepLearning.Domain.Queries.GetCountries
{
    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, Countries>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public GetCountriesQueryHandler(ICountryRepository countryRepository, ICountryService countryService, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _countryService = countryService;
            _mapper = mapper;
        }

        public async Task<Countries> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            var continents = request.Continents.Select(Continent.MapContinentToString);
            var countries = await _countryRepository.GetByContinents(continents);

            var contriesDto = _mapper.Map<Countries>(countries);

            return contriesDto;
        }
    }
}
