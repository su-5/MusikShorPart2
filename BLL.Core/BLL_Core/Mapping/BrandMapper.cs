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
                .ForMember(d => d.Id, opts => opts.MapFrom(src => src.Id));

            CreateMap<BrandDTO, Brand>()
                .ForMember(d => d.CreateDate, opts => opts.Ignore())
                .ForMember(d => d.DeleteDate, opts => opts.Ignore())
                .ForMember(d => d.Description, opts => opts.MapFrom(src => src.Description))
                .ForMember(d => d.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(d => d.Id, opts => opts.Ignore())
                .ForMember(d => d.Products, opts => opts.Ignore());
            //  .ForMember(d => d.Description, opts => opts.MapFrom(src => src.Description))
            // .ForMember(d => d.Products, opts => opts.MapFrom(null))
            //  .ForMember(d => d.Name, opts => opts.MapFrom(src => src.Name));
        }
    }
}
