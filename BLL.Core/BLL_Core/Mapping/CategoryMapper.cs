using AutoMapper;
using DAL.Core;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Mapping
{

    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<CategoryDTO, Category>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id));


        }
    }
}