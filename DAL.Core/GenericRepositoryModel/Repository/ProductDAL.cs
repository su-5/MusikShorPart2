using System;
using System.Linq;
using System.Linq.Expressions;
using DAL.Core.DAL_Core;
using DAL.Core.GenericRepository;
using DAL.Core.GenericRepositoryModel.Interfaces;

namespace DAL.Core.GenericRepositoryModel.Repository
{
   public class ProductDAL : GenericRepository<Product>, IProductDAL
   {
       public ProductDAL(IDbFactory dbFactory) : base(dbFactory)
       {
       }

       public IQueryable<Product> GetAllWithPaging<TKey>(int pageSize, int page, out int total, Expression<Func<Product, TKey>> orderBy, bool isOrderAsc,
           Expression<Func<Product, bool>> filter = null)
       {
           throw new NotImplementedException();
       }
   }
}
