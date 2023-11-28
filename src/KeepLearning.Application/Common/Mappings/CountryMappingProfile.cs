using AutoMapper;
using KeepLearning.Application.Common.Models.Country;
using KeepLearning.Domain.Enteties;

namespace KeepLearning.Application.Common.Mappings
{
    public class CountryMappingProfile : Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<Country, CountryDto>();
        }
    }
}
