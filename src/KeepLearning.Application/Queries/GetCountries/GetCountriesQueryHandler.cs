using AutoMapper;
using KeepLearning.Domain.Interfaces;
using KeepLearning.Domain.Models;
using MediatR;

namespace KeepLearning.Domain.Queries.GetCountries
{
    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, Countries>
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public GetCountriesQueryHandler(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        public async Task<Countries> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            var countries = await _countryService.GetCountries(request.Continents);

            var contriesDto = _mapper.Map<Countries>(countries);

            return contriesDto;
        }
    }
}
