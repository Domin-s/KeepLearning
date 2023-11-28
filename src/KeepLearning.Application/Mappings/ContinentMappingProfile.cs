using AutoMapper;
using KeepLearning.Domain.Enteties;
using KeepLearning.Domain.Models.Continent;

namespace KeepLearning.Domain.Mappings
{
    public class ContinentMappingProfile : Profile
    {
        public ContinentMappingProfile()
        {
            CreateMap<Continent, ContinentDto>();
        }
    }
}
