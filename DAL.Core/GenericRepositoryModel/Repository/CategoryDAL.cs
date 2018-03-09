using DAL.Core.DAL_Core;
using DAL.Core.GenericRepository;
using DAL.Core.GenericRepositoryModel.Interfaces;

namespace DAL.Core.GenericRepositoryModel.Repository
{
    public class CategoryDAL : GenericRepository<Category>, ICategoryDAL
    {
        public CategoryDAL(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}