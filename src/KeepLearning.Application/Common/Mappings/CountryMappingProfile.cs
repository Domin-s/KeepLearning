using AutoMapper;
using KeepLearning.Application.Common.Models.Country;

namespace KeepLearning.Application.Common.Mappings
{
    public class CountryMappingProfile : Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<Domain.Enteties.Country, CountryDto>();
        }
    }
}
