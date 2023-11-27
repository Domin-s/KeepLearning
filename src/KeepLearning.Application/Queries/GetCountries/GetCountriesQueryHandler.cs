using AutoMapper;
using KeepLearning.Domain.Exceptions;
using KeepLearning.Domain.Interfaces;
using KeepLearning.Domain.Models;
using MediatR;

namespace KeepLearning.Domain.Queries.GetCountries
{
    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, Countries>
    {
        private readonly IContinentRepository _continentRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public GetCountriesQueryHandler(IContinentRepository continentRepository, ICountryRepository countryRepository, IMapper mapper)
        {
            _continentRepository = continentRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<Countries> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            var continents = await _continentRepository.GetByNames(request.Continents.Select(c => c.Name));
            if (!continents.Any())
            {
                throw new NotFoundException("Not found any continents");
            }

            var countries = await _countryRepository.GetByContinents(continents);

            var contriesDto = _mapper.Map<Countries>(countries);

            return contriesDto;
        }
    }
}
