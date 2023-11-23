using AutoMapper;
using KeepLearning.Domain.Interfaces;
using KeepLearning.Domain.Models;
using MediatR;

namespace KeepLearning.Domain.Queries.GetCountries
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
            var continents = string.Join(",", request.Continents);
            var countries = await _countryRepository.GetByContinents(continents);

            var contriesDto = _mapper.Map<Countries>(countries);

            return contriesDto;
        }
    }
}
