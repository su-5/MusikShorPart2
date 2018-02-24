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
                .ForMember(d => d.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(d => d.Number, opts => opts.MapFrom(src => src.Number));

        }
    }
}
