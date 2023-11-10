using KeepLearning.Domain.Enteties;
using KeepLearning.Domain.Interfaces;
using KeepLearning.Domain.Models.Enums;
using static KeepLearning.Domain.Models.Enums.GuessType;

namespace KeepLearning.Infrastructure.Services
{
    internal class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<Country> GetRandomCountry(IEnumerable<Continent.Name> continents)
        {;
            var countries = await GetCountries(continents);

            var randomNumber = new Random().Next(0, countries.Count());

            return countries.ToList()[randomNumber];
        }

        public async Task<IEnumerable<Country>> GetRandomCountries(IEnumerable<Continent.Name> continents, int numberOfQuestions)
        {
            var pickedUpCountries = new List<Country>();
            var countriesToChoose = await GetCountries(continents);

            while (pickedUpCountries.Count < numberOfQuestions)
            {
                Country randomCountry = await GetRandomCountry(continents);

                if (!pickedUpCountries.Contains(randomCountry))
                {
                    pickedUpCountries.Add(randomCountry);
                }
            }

            return pickedUpCountries;
        }

        public async Task<Country?> GetCountry(string questionText, GuessType.Value guessType)
        {
            switch (guessType)
            {
                case Value.CapitalCity:
                    return await _countryRepository.GetByName(questionText);

                case Value.Country:
                    return await _countryRepository.GetByCapitalCity(questionText);

                default:
                    throw new NotImplementedException();
            }
        }

        public async Task<IEnumerable<Country>> GetCountries(IEnumerable<Continent.Name> continents)
        {
            if (continents.Any())
            {
                var stringContinents = continents.Select(Continent.MapContinentToString);
                return await _countryRepository.GetByContinents(stringContinents);
            }
            else
            {
                return await _countryRepository.GetAll();
            }
        }

        public bool IsCorrectAnswer(Country country, string answerText, GuessType.Value guessType)
        {
            switch (guessType)
            {
                case Value.Country:
                    return country.Name.Equals(answerText);

                case Value.CapitalCity:
                    return country.CapitalCity.Equals(answerText);

                default: return false;
            }
        }
    }
}
