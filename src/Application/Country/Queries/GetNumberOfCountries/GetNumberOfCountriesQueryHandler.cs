using Domain.Interfaces;
using MediatR;

namespace Application.Country.Queries.GetNumberOfCountries
{
    public class GetNumberOfCountriesQueryHandler : IRequestHandler<GetNumberOfCountriesQuery, int>
    {
        private readonly IContinentRepository _continentRepository;
        private readonly ICountryRepository _countryRepository;

        public GetNumberOfCountriesQueryHandler(IContinentRepository continentRepository, ICountryRepository countryRepository)
        {
            _continentRepository = continentRepository;
            _countryRepository = countryRepository;
        }

        public async Task<int> Handle(GetNumberOfCountriesQuery request, CancellationToken cancellationToken)
        {
            var continents = await _continentRepository.GetByNames(request.Continents.Select(c => c.Name));
            var continentIds = continents.Select(c => c.Id);
            var numberOfCountries = await _countryRepository.GetNumberOfCountries(continentIds);

            return numberOfCountries;
        }
    }
}
