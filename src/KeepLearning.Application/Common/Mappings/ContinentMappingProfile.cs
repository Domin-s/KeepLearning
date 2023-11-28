using AutoMapper;
using KeepLearning.Application.Common.Models.Continent;
using KeepLearning.Domain.Enteties;

namespace KeepLearning.Application.Common.Mappings
{
    public class ContinentMappingProfile : Profile
    {
        public ContinentMappingProfile()
        {
            CreateMap<Continent, ContinentDto>();
        }
    }
}
