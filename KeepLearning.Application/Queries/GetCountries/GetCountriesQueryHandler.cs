using AutoMapper;
using KeepLearning.Application.Country;
using KeepLearning.Application.Models.Enums;
using KeepLearning.Domain.Interfaces;
using MediatR;

namespace KeepLearning.Application.Queries.GetCountries
{
    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, Countries>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public GetCountriesQueryHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<Countries> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            var countries = await GetCountries(request.Continents);

            var contriesDto = _mapper.Map<Countries>(countries);

            return contriesDto;
        }

        private async Task<Countries> GetCountries(IEnumerable<Continent.Name> continents)
        {
            if (continents.Any())
            {
                var stringContinents = continents.Select(c => Continent.MapContinentToString(c));
                return await _countryRepository.GetByContinents(stringContinents);
            }
            else
            {
                return await _countryRepository.GetAll();
            }
        }
    }
}
