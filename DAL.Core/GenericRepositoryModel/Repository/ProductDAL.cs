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
   }
}
