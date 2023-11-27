using KeepLearning.Domain.Enteties;
using KeepLearning.Infrastructure.Persistence;

namespace KeepLearning.Infrastructure.Seeders
{
    public class CountrySeeder
    {
        private readonly KeepLearningDbContext _dbContext;

        public CountrySeeder(KeepLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Countries.Any())
                {
                    var countries = GetCountriesFromFile();

                    if (countries != null)
                    {
                        countries.ToList().ForEach(country =>
                        {
                            _dbContext.Countries.AddRangeAsync(country);
                            _dbContext.SaveChangesAsync();
                        });
                    }
                }
            }
        }

        private IEnumerable<Country> GetCountriesFromFile()
        {
            IEnumerable<Country> countries = new List<Country>();

            try
            {
                countries = File.ReadAllLines("../KeepLearning.Infrastructure/Seeders/FilesWithData/WorldCountriesList.csv")
                    .Skip(1)
                    .Select(c => c.Split(','))
                    .Select(d =>
                    {
                        var continent = new Continent()
                        {
                            Id = Guid.NewGuid(),
                            Name = d[3]
                        };

                        return new Country()
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
