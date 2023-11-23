using KeepLearning.Domain.Interfaces;
using MediatR;

namespace KeepLearning.Domain.Queries.GetNumberOfCountries
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
            var continents = string.Join(",", request.Continents);

            var numberOfCountries = await _countryRepository.GetNumberOfCountries(continents);

            return numberOfCountries;
        }
    }
}
