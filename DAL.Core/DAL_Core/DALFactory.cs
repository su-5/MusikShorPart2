using DAL.Core.GenericRepositoryModel.Interfaces;
using DAL.Core.GenericRepositoryModel.Repository;

namespace DAL.Core.DAL_Core
{
    public class DalFactory : IDALFactory
    {
        private IProductDAL _product;
        private IBrandDAL _brand;
        private MusicDataBaseEntities _dbContext;
        private readonly IDbFactory _dbFactory;

        public DalFactory(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public IBrandDAL Brand => _brand ?? (_brand = new BrandDAL(_dbFactory));
        public MusicDataBaseEntities DbContext => _dbContext ?? (_dbContext = _dbFactory.Init());
        public IProductDAL Product => _product ?? (_product = new ProductDAL(_dbFactory));
    }

}
