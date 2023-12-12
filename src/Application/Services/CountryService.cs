using Application.Common.Interfaces;
using Domain.Enteties;
using Domain.Interfaces;
using Domain.Models.Enums;
using static Domain.Models.Enums.GuessType;

namespace Infrastructure.Services
{
    public class CountryService : ICountryService
    {
        private readonly IKeepLearningDbContext _dbContext;

        public CountryService(IKeepLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Country?> GetRandom(Guid continentId)
        {
            var countries = await RandomCountries(new List<Guid>() { continentId }, 1);

            return countries.FirstOrDefault();
        }

        public async Task<IEnumerable<Country>> RandomCountries(IEnumerable<Guid> continentIds, int numberOfCountries)
        {
            var countries = await _dbContext.Countries
                    .Where(country => continentIds.Contains(country.ContinentId))
                    .ToListAsync();

            if (countries is null)
            {
                throw new NotFoundException(string.Join(",", continentIds), "Countries");
            }

            if (countries.Count() < numberOfCountries)
            {
                throw new InvalidDataException("Number of countries to choose is bigger than number of countries in continents that user chosen");
            }

            var random = new Random();

            var randomCountries = countries.OrderBy(country => random.Next()).Take(numberOfCountries);

            return randomCountries;
        }

        public async Task<string> GetCorrectAnswer(string questionText, GuessType.Category category)
        {
            var country = await GetCountry(questionText, category);

            if (country == null)
                throw new NotFoundException(questionText, "Country");

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

        public async Task<bool> IsCorrectAnswer(string questionText, string answerText, GuessType.Category category)
        {
            var country = await GetCountry(questionText, category);
            if (country == null)
                throw new NotFoundException(questionText, "Country");

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

        private async Task<Country?> GetCountry(string questionText, GuessType.Category category)
        {
            switch (category)
            {
                case Category.CapitalCity:
                    return await _dbContext.Countries.FirstAsync(country => country.Name == questionText);

                case Category.Country:
                    return await _dbContext.Countries.FirstAsync(country => country.CapitalCity == questionText);

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
