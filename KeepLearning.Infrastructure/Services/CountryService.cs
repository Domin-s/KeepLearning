using KeepLearning.Domain.Models.Enums;
using KeepLearning.Domain.Interfaces;
using static KeepLearning.Domain.Models.Enums.GuessType;
using KeepLearning.Domain.Models;

namespace KeepLearning.Infrastructure.Services
{
    internal class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public Domain.Enteties.Country GetRandomCountry(IEnumerable<Domain.Enteties.Country> ListOfCountry)
        {
            var randomNumber = new Random().Next(0, ListOfCountry.Count());

            return ListOfCountry.ToList()[randomNumber];
        }

        public IEnumerable<Domain.Enteties.Country> GetRandomCountries(int numberOfQuestions)
        {
            var pickedUpCountries = new List<Domain.Enteties.Country>();

            while (pickedUpCountries.Count < numberOfQuestions)
            {
                Domain.Enteties.Country randomCountry = GetRandomCountry(pickedUpCountries);

                if (!pickedUpCountries.Contains(randomCountry))
                {
                    pickedUpCountries.Add(randomCountry);
                }
            }

            return pickedUpCountries;
        }

        public async Task<Domain.Enteties.Country?> GetCountry(string questionText, GuessType.Value guessType)
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

        public async Task<Countries> GetCountries(IEnumerable<Continent.Name> continents)
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

        public bool IsCorrectAnswer(Domain.Enteties.Country country, string answerText, GuessType.Value guessType)
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
