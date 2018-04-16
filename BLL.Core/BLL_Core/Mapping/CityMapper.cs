using AutoMapper;
using DAL.Core;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Mapping
{
    public class CityMapper : Profile
    {
        public CityMapper()
        {
            CreateMap<City,CityDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.RegionId, opt => opt.MapFrom(src => src.RegionId));
        }
    }
}