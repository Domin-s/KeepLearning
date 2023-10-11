using AutoMapper;
using KeepLearning.Application.Models.Country;

namespace KeepLearning.Application.Mappings
{
    public class CountryMappingProfile : Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<Domain.Enteties.Country, CountryDto>();
        }
    }
}
