using DAL.Core.DAL_Core;
using DAL.Core.GenericRepository;
using DAL.Core.GenericRepositoryModel.Interfaces;

namespace DAL.Core.GenericRepositoryModel.Repository
{
    public class NumberStringDAL:GenericRepository<NumberString>, INumberStringDAL
    {
       

        public NumberStringDAL(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}