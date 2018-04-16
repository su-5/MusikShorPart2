using DAL.Core.DAL_Core;
using DAL.Core.GenericRepository;
using DAL.Core.GenericRepositoryModel.Interfaces;

namespace DAL.Core.GenericRepositoryModel.Repository
{
    public class CityDAL:GenericRepository<City>, ICityDAL
    {
        public CityDAL(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}