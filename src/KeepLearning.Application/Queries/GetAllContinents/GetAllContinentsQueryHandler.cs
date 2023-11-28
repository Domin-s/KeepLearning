using AutoMapper;
using KeepLearning.Domain.Interfaces;
using KeepLearning.Domain.Models.Continent;
using MediatR;

namespace KeepLearning.Domain.Queries.GetAllContinents
{
    public class GetAllContinentsQueryHandler : IRequestHandler<GetAllContinentsQuery, IEnumerable<ContinentDto>>
    {
        private readonly IContinentRepository _continentRepository;
        private readonly IMapper _mapper;

        public GetAllContinentsQueryHandler(IContinentRepository continentRepository, IMapper mapper)
        {
            _continentRepository = continentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContinentDto>> Handle(GetAllContinentsQuery request, CancellationToken cancellationToken)
        {
            var continents = await _continentRepository.GetAll();

            var continentsDto = continents.Select(c => _mapper.Map<ContinentDto>(c));

            return continentsDto;
        }
    }
}
