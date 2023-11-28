using AutoMapper;
using KeepLearning.Application.Common.Models.Continent;
namespace KeepLearning.Application.Common.Mappings
{
    public class ContinentMappingProfile : Profile
    {
        public ContinentMappingProfile()
        {
            CreateMap<Domain.Enteties.Continent, ContinentDto>();
        }
    }
}
