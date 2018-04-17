using DAL.Core.DAL_Core;
using DAL.Core.GenericRepository;
using DAL.Core.GenericRepositoryModel.Interfaces;

namespace DAL.Core.GenericRepositoryModel.Repository
{
    public class PaymentSystemDAL: GenericRepository<PaymentSystem>, IPaymentSystemDAL
    {
        public PaymentSystemDAL(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}