using Application.Common.Interfaces;
using Application.Common.Models.Country;
using Application.Common.Models.Question;
using Infrastructure.Services;

namespace Application.Question.Queries.GetRandomQuestion;

public class GetRandomQuestionQueryHandler : IRequestHandler<GetRandomQuestionQuery, QuestionDto>
{
    private readonly IKeepLearningDbContext _dbContext;
    private readonly CountryService _countryService;
    private readonly IMapper _mapper;

    public GetRandomQuestionQueryHandler(IKeepLearningDbContext dbContext, CountryService countryService, IMapper mapper)
    {
        _dbContext = dbContext;
        _countryService = countryService;
        _mapper = mapper;
    }

    public async Task<QuestionDto> Handle(GetRandomQuestionQuery request, CancellationToken cancellationToken)
    {
        var continent = await _dbContext.Continents.Where(c => c.Name == request.Continent).FirstAsync();
        if (continent is null)
        {
            throw new NotFoundException(request.Continent, "Not found continent!");
        }

        var randomCountry = await _countryService.GetRandom(continent.Id);
        if (randomCountry is null)
        {
            throw new NotFoundException(continent.Id.ToString(), "Not found country");
        }

        var countryDto = _mapper.Map<CountryDto>(randomCountry);

        return QuestionDtoBuilder.CreateQuestionByCategory(countryDto, request.Category);
    }
}
