﻿using KeepLearning.Domain.Enteties;
using KeepLearning.Domain.Exceptions;
using KeepLearning.Domain.Interfaces;
using KeepLearning.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;
using static KeepLearning.Domain.Models.Enums.GuessType;

namespace KeepLearning.Infrastructure.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<Country?> GetRandom(Guid continentId)
        {
            var countries = await RandomCountries(new List<Guid>() { continentId }, 1);

            return countries.FirstOrDefault();
        }

        public async Task<IEnumerable<Country>> RandomCountries(IEnumerable<Guid> continentIds, int numberOfCountries)
        {
            var countries = await _countryRepository.GetByContinents(continentIds);

            if (countries is null)
            {
                throw new Domain.Exceptions.NotFoundException("Not found countires");
            }

            if (countries.Count() < numberOfCountries)
            {
                throw new Domain.Exceptions.InvalidDataException("Number of countries to choose is bigger than number of countries in continents that user chosen");
            }

            var random = new Random();

            var randomCountries = countries.OrderBy(country => random.Next()).Take(numberOfCountries);

            return randomCountries;
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

        public async Task<bool> IsCorrectAnswer(string questionText, string answerText, GuessType.Category category)
        {
            var country = await GetCountry(questionText, category);
            if (country == null)
                throw new NotFoundException("Not found conutry");

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
                    return await _countryRepository.GetByName(questionText);

                case Category.Country:
                    return await _countryRepository.GetByCapitalCity(questionText);

                default:
                    throw new NotImplementedException();
            }
        }
    }
}