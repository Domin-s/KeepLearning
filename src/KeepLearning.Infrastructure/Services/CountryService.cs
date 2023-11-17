using KeepLearning.Domain.Enteties;
using KeepLearning.Domain.Interfaces;
using KeepLearning.Domain.Models.Enums;
using RestaurantAPI.Exceptions;
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
        {
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

        public async Task<Country?> GetCountry(string questionText, GuessType.Category category)
        {
            switch (category)
            {
                case Category.CapitalCity:
                    return await _countryRepository.GetByName(questionText);

                case Category.Country:
                    return await _countryRepository.GetByCapitalCity(questionText);

                default:
                    throw new NotImplementedException();
            }
        }

        public async Task<string> GetCorrectAnswer(string questionText, GuessType.Category category)
        {
            var country = await GetCountry(questionText, category);

            if (country == null)
                throw new NotFoundException("Not found conutry");

            switch (category)
            {
                case Category.CapitalCity:
                    return country.CapitalCity;

                case Category.Country:
                    return country.Name;

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

        public bool IsCorrectAnswer(Country country, string answerText, GuessType.Category category)
        {
            if (answerText is null)
                return false;

            switch (category)
            {
                case Category.Country:
                    return country.Name.ToLower().Equals(answerText.ToLower());

                case Category.CapitalCity:
                    return country.CapitalCity.ToLower().Equals(answerText.ToLower());

                default: return false;
            }
        }
    }
}
