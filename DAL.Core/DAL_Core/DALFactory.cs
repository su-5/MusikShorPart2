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
        private IOrderDAL _order;
        private IOrdersProductDAL _ordersProduct;
        private ICityDAL _city;
        private IRegionDAL _region;
        private IUsersProductDAL _usersProduct;
        private IPaymentSystemDAL _paymentSystem;

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
        public IOrderDAL Order => _order ?? (_order = new OrderDAL(_dbFactory));
        public IOrdersProductDAL OrdersProduct => _ordersProduct ?? (_ordersProduct = new OrdersProductDAL(_dbFactory));
        public ICityDAL City => _city ?? (_city = new CityDAL(_dbFactory));
        public IRegionDAL Region => _region ?? (_region = new RegionDAL(_dbFactory));
        public IUsersProductDAL UsersProduct => _usersProduct ?? (_usersProduct = new UsersProductDAL(_dbFactory));
        public IPaymentSystemDAL PaymentSystem => _paymentSystem ?? (_paymentSystem = new PaymentSystemDAL(_dbFactory));
    }

}
