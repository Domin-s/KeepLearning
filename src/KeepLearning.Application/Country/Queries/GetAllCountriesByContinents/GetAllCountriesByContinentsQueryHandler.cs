using AutoMapper;
using KeepLearning.Application.Common.Models.Country;
using KeepLearning.Domain.Exceptions;
using KeepLearning.Domain.Interfaces;
using MediatR;

namespace KeepLearning.Application.Country.Queries.GetAllCountriesByContinents
{
    public class GetAllCountriesByContinentsQueryHandler : IRequestHandler<GetAllCountriesByContinentsQuery, IEnumerable<CountryDto>>
    {
        private readonly IContinentRepository _continentRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public GetAllCountriesByContinentsQueryHandler(IContinentRepository continentRepository, ICountryRepository countryRepository, IMapper mapper)
        {
            _continentRepository = continentRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CountryDto>> Handle(GetAllCountriesByContinentsQuery request, CancellationToken cancellationToken)
        {
            var continentNames = request.ContinentDtos.Select(c => c.Name);
            var continents = await _continentRepository.GetByNames(continentNames);
            if (continents is null )
            {
                throw new NotFoundException("Not found any continent");
            }

            var continentIds = continents.Select(c => c.Id);

            var countries = await _countryRepository.GetByContinents(continentIds);

            var contriesDto = countries.Select( c => _mapper.Map<CountryDto>(c));

            return contriesDto;
        }
    }
}
