using DAL.Core.DAL_Core;
using DAL.Core.GenericRepository;
using DAL.Core.GenericRepositoryModel.Interfaces;

namespace DAL.Core.GenericRepositoryModel.Repository
{
    public class CountryDAL:GenericRepository<Country>, ICountryDAL
    {
        public CountryDAL(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}