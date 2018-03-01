using DAL.Core.DAL_Core;
using DAL.Core.GenericRepository;
using DAL.Core.GenericRepositoryModel.Interfaces;

namespace DAL.Core.GenericRepositoryModel.Repository
{
    public class BrandDAL: GenericRepository<Brand>, IBrandDAL
    {
        public BrandDAL(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
