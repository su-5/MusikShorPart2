using AutoMapper;
using DAL.Core;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Mapping
{
    public class RegionMapper : Profile
    {
        public RegionMapper()
        {
            CreateMap<Region, RegionDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.CountryId, opt => opt.MapFrom(src => src.CountryId));
        }
    }
}