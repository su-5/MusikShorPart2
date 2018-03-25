using DAL.Core.DAL_Core;
using DAL.Core.GenericRepository;
using DAL.Core.GenericRepositoryModel.Interfaces;

namespace DAL.Core.GenericRepositoryModel.Repository
{
    public class UserDAL:GenericRepository<User>, IUserDAL
    {
        public UserDAL(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}