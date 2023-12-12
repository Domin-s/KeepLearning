using Application.Common.Interfaces;
using Application.Common.Models.Country;

namespace Application.Country.Queries.GetAllCountriesByContinents;

public class GetCountriesByContinentsQueryHandler : IRequestHandler<GetCountriesByContinentsQuery, IEnumerable<CountryDto>>
{
    private readonly IKeepLearningDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetCountriesByContinentsQueryHandler(IKeepLearningDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CountryDto>> Handle(GetCountriesByContinentsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Domain.Enteties.Country> countries = new List<Domain.Enteties.Country>();

        var continentNames = request.ContinentDtos.Select(c => c.Name);
        var continents = await _dbContext.Continents.Where(c => continentNames.Contains(c.Name)).ToListAsync();

        if (continents.Count() == 0)
        {
            countries = await _dbContext.Countries
                .Include(c => c.Continent)
                .ToListAsync();
        } else
        {
            var continentIds = continents.Select(c => c.Id);

            countries = await _dbContext.Countries
                .Include(c => c.Continent)
                .Where(country => continentIds.Contains(country.ContinentId))
                .ToListAsync();
        }

        var contriesDto = countries.Select( c => _mapper.Map<CountryDto>(c));

        return contriesDto;
    }
}
