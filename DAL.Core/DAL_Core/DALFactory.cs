using DAL.Core.GenericRepositoryModel.Interfaces;
using DAL.Core.GenericRepositoryModel.Repository;

namespace DAL.Core.DAL_Core
{
    public class DalFactory : IDALFactory
    {
        private IProductDAL _product;
        private IBrandDAL _brand;
        private ICountryDAL _country;
        private INumberStringDAL _numberString;
        private ISubcategoryDAL _subcategory;
        private ICategoryDAL _category;
        private IUserDAL _user;
        private MusicDataBaseEntities _dbContext;
        private readonly IDbFactory _dbFactory;

        public DalFactory(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public IBrandDAL Brand => _brand ?? (_brand = new BrandDAL(_dbFactory));
        public ICountryDAL Country => _country ?? (_country = new CountryDAL(_dbFactory));
        public INumberStringDAL NumberString => _numberString ?? (_numberString = new NumberStringDAL(_dbFactory));
        public ISubcategoryDAL Subcategory => _subcategory ?? (_subcategory = new SubcategoryDAL(_dbFactory));
        public MusicDataBaseEntities DbContext => _dbContext ?? (_dbContext = _dbFactory.Init());
        public IProductDAL Product => _product ?? (_product = new ProductDAL(_dbFactory));
        public ICategoryDAL Category => _category ?? (_category = new CategoryDAL(_dbFactory));
        public IUserDAL User => _user ?? (_user = new UserDAL(_dbFactory));
    }

}
