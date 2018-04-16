using DAL.Core.DAL_Core;
using DAL.Core.GenericRepository;
using DAL.Core.GenericRepositoryModel.Interfaces;

namespace DAL.Core.GenericRepositoryModel.Repository
{
    public class UsersProductDAL:GenericRepository<UsersProduct>, IUsersProductDAL
    {
        public UsersProductDAL(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}