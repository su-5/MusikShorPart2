using AutoMapper;
using DAL.Core;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Mapping
{
    public class NumberStringMapper : Profile
    {
        public NumberStringMapper()
        {
            CreateMap<NumberString, NumberStringDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Number, opt => opt.MapFrom(src => src.Number));

            CreateMap<NumberStringDTO, NumberString>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Number, opt => opt.MapFrom(src => src.Number));

        }
    }
}
