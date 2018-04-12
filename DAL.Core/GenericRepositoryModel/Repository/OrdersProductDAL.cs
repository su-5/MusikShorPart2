using DAL.Core.DAL_Core;
using DAL.Core.GenericRepository;
using DAL.Core.GenericRepositoryModel.Interfaces;

namespace DAL.Core.GenericRepositoryModel.Repository
{
    class OrdersProductDAL : GenericRepository<OrdersProduct>, IOrdersProductDAL
    {
        public OrdersProductDAL(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
