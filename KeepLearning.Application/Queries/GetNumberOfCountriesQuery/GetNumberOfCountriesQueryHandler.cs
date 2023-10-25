using KeepLearning.Application.Models.Enums;
using KeepLearning.Domain.Interfaces;
using MediatR;

namespace KeepLearning.Application.Queries.GetNumberOfCountriesQuery
{
    public class GetNumberOfCountriesQueryHandler : IRequestHandler<GetNumberOfCountriesQuery, int>
    {
        private readonly ICountryRepository _countryRepository;

        public GetNumberOfCountriesQueryHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<int> Handle(GetNumberOfCountriesQuery request, CancellationToken cancellationToken)
        {
            var mappedContinent = request.Continents.Select(c => Continent.MapContinentToString(c));

            var numberOfCountries = await _countryRepository.GetNumberOfCountries(mappedContinent);

            return numberOfCountries;
        }
    }
}
