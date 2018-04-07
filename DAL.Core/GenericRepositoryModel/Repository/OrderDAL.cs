using DAL.Core.DAL_Core;
using DAL.Core.GenericRepository;
using DAL.Core.GenericRepositoryModel.Interfaces;

namespace DAL.Core.GenericRepositoryModel.Repository
{
    public class OrderDAL:GenericRepository<Order>, IOrderDAL
    {
        public OrderDAL(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}