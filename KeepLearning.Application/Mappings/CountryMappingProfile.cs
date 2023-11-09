using AutoMapper;
using KeepLearning.Domain.Models.Country;

namespace KeepLearning.Domain.Mappings
{
    public class CountryMappingProfile : Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<Domain.Enteties.Country, CountryDto>();
        }
    }
}
