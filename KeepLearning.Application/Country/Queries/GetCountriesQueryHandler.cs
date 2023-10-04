using AutoMapper;
using KeepLearning.Domain.Interfaces;
using MediatR;

namespace KeepLearning.Application.Country.Queries
{
    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, IEnumerable<CountryDto>>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public GetCountriesQueryHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CountryDto>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            var countries = await GetCountries(request.Continents);

            var contriesDto = _mapper.Map<IEnumerable<CountryDto>>(countries);

            return contriesDto;
        }

        private async Task<IEnumerable<Domain.Enteties.Country>> GetCountries(IEnumerable<string> continents)
        {
            if (continents.Any())
            {
                return await _countryRepository.GetByContinent(continents);
            }
            else
            {
                return await _countryRepository.GetAll();
            }
        }
    }
}
