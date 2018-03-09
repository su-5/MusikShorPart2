using AutoMapper;
using DAL.Core;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Mapping
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, AppUserDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<AppUserDto, User>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
