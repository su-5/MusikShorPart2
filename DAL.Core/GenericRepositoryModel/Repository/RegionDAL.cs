using DAL.Core.DAL_Core;
using DAL.Core.GenericRepository;
using DAL.Core.GenericRepositoryModel.Interfaces;

namespace DAL.Core.GenericRepositoryModel.Repository
{
    public class RegionDAL: GenericRepository<Region>, IRegionDAL
    {
        public RegionDAL(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}