using AutoMapper;
using KeepLearning.Domain.Enteties;
using KeepLearning.Domain.Models.Country;

namespace KeepLearning.Domain.Mappings
{
    public class CountryMappingProfile : Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<Country, CountryDto>();
        }
    }
}
