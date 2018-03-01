using AutoMapper;
using DAL.Core;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Mapping
{

    public class SubcategoryMapper : Profile
    {
        public SubcategoryMapper()
        {
            CreateMap<Subcategory, SubcategoryDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<SubcategoryDTO, Subcategory>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id));


        }
    }
}