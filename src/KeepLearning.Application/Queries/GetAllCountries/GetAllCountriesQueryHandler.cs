using AutoMapper;
using KeepLearning.Domain.Interfaces;
using KeepLearning.Domain.Models;
using MediatR;

namespace KeepLearning.Domain.Queries.GetAllCountries
{
    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, Countries>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public GetAllCountriesQueryHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<Countries> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            var countries = await _countryRepository.GetAll();

            var contriesDto = _mapper.Map<Countries>(countries);

            return contriesDto;
        }
    }
}
