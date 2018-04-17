using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Core.BLL_Core.Interface;
using DAL.Core;
using DAL.Core.DAL_Core;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Repository
{
    public class PaymentSystemBLL : IPaymentSystemBLL
    {
        private readonly DalFactory _dalFactory;

        public PaymentSystemBLL(DalFactory dalFactory)
        {
            _dalFactory = dalFactory;
        }

        public List<PaymentSystemDTO> GetAll()
        {
            List<PaymentSystem> paymentSystemsList = _dalFactory.PaymentSystem.GetAll().Where(w => w.NamePaymentSystems != null).OrderBy(x => x.NamePaymentSystems).ToList();
            var result = Mapper.Map<List<PaymentSystem>, List<PaymentSystemDTO>>(paymentSystemsList);
            return result;
        }
    }
}