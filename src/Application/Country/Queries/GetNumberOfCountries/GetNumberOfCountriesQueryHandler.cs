using Application.Common.Interfaces;

namespace Application.Country.Queries.GetNumberOfCountries;

public class GetNumberOfCountriesQueryHandler : IRequestHandler<GetNumberOfCountriesQuery, int>
{
    private readonly IKeepLearningDbContext _dbContext;

    public GetNumberOfCountriesQueryHandler(IKeepLearningDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(GetNumberOfCountriesQuery request, CancellationToken cancellationToken)
    {
        var continentNames = request.Continents.Select(c => c.Name);
        var continents = await _dbContext.Continents.Where(c => continentNames.Contains(c.Name)).ToListAsync();
        var continentIds = continents.Select(c => c.Id);
        var numberOfCountries = await _dbContext.Countries.Where(country => continentIds.Contains(country.ContinentId)).CountAsync();

        return numberOfCountries;
    }
}
