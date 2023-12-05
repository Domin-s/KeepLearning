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
            IEnumerable<Domain.Enteties.Country> countries = new List<Domain.Enteties.Country>();

            var continentNames = request.ContinentDtos.Select(c => c.Name);
            var continents = await _continentRepository.GetByNames(continentNames);

            if (continents.Count() == 0)
            {
                countries = await _countryRepository.GetAll();
            } else
            {
                var continentIds = continents.Select(c => c.Id);

                countries = await _countryRepository.GetByContinents(continentIds);
            }

            var contriesDto = countries.Select( c => _mapper.Map<CountryDto>(c));

            return contriesDto;
        }
    }
}
