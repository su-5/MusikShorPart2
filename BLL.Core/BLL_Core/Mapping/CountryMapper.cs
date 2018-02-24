using AutoMapper;
using DAL.Core;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Mapping
{
    public class CountryMapper : Profile
    {
        public CountryMapper()
        {
            CreateMap<Country, CountryDTO>()
                .ForMember(d => d.Id, opts => opts.MapFrom(src => src.Id));

        }
    }
}
