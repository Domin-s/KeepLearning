using AutoMapper;
using KeepLearning.Application.Models.Country;
using KeepLearning.Application.TestCountry.Models;

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
