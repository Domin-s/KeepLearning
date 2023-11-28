﻿using KeepLearning.Domain.Enteties;

namespace KeepLearning.ApplicationTests.Helper.Country
{
    public static class CountryData
    {

        public static IEnumerable<Domain.Enteties.Country> GetCountries()
        {
            IEnumerable<Domain.Enteties.Country> countries = new List<Domain.Enteties.Country>();

            try
            {
                countries = File.ReadAllLines("../../../../KeepLearning.ApplicationTests/Helper/Files/WorldCountriesList.csv")
                    .Skip(1)
                    .Select(c => c.Split(','))
                    .Select(d =>
                    {
                        var continent = new Continent()
                        {
                            Id = Guid.NewGuid(),
                            Name = d[3]
                        };


                        return new Domain.Enteties.Country()
                        {
                            Id = Guid.NewGuid(),
                            Name = d[0],
                            Abbreviation = d[1],
                            CapitalCity = d[2],
                            ContinentId = continent.Id,
                            Continent = continent
                        };
                    });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return countries;
        }
    }
}