using Infrastructure.Persistence;
using EContinent = Domain.Enteties.Continent;

namespace Application.Helper.Seeders.IntegrationTests
{
    public class ContinentSeederTest
    {
        private readonly KeepLearningDbContext _dbContext;

        public ContinentSeederTest(KeepLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
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

        private IEnumerable<EContinent> GetContinentsFromFile()
        {
            IEnumerable<EContinent> countries = new List<EContinent>();

            try
            {
                countries = File.ReadAllLines("../../../Helper/Seeders/FilesWithData/ContinentsList.csv")
                    .Skip(1)
                    .Select(name => new EContinent()
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
