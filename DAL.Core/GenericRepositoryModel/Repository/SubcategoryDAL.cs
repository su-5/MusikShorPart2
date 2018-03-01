using DAL.Core.DAL_Core;
using DAL.Core.GenericRepository;
using DAL.Core.GenericRepositoryModel.Interfaces;

namespace DAL.Core.GenericRepositoryModel.Repository
{
    public class SubcategoryDAL : GenericRepository<Subcategory>, ISubcategoryDAL
    {


        public SubcategoryDAL(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}