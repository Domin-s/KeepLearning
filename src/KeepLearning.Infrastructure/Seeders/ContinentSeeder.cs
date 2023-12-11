using KeepLearning.Domain.Enteties;
using KeepLearning.Infrastructure.Persistence;

namespace KeepLearning.Infrastructure.Seeders
{
    public class ContinentSeeder
    {
        private readonly KeepLearningDbContext _dbContext;

        public ContinentSeeder(KeepLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Continents.Any())
                {
                    var continents = GetContinentsFromFile();

                    if (continents != null)
                    {
                        continents.ToList().ForEach(continent =>
                        {
                            _dbContext.Continents.Add(continent);
                            _dbContext.SaveChanges();
                        });
                    }
                }
            }
        }

        private IEnumerable<Continent> GetContinentsFromFile()
        {
            IEnumerable<Continent> countries = new List<Continent>();

            try
            {
                countries = File.ReadAllLines("../KeepLearning.Infrastructure/Seeders/FilesWithData/ContinentsList.csv")
                    .Skip(1)
                    .Select(name => new Continent()
                    {
                        Name = name
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
