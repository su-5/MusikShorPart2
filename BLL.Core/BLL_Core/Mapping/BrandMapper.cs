using System.Runtime.InteropServices;
using AutoMapper;
using DAL.Core;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Mapping
{
    public class BrandMapper : Profile
    {
        public BrandMapper()
        {
            CreateMap<Brand, BrandDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<BrandDTO, Brand>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id));

        }
    }
}
