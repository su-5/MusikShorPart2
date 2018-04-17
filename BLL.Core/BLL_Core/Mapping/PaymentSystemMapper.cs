using AutoMapper;
using DAL.Core;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Mapping
{
    public class PaymentSystemMapper: Profile
    {
        public PaymentSystemMapper()
        {
            CreateMap<PaymentSystem, PaymentSystemDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.NamePaymentSystems, opt => opt.MapFrom(src => src.NamePaymentSystems));
        }
    }
}