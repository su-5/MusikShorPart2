using BLL.Core.BLL_Core.Interface;
using DAL.Core.DAL_Core;

namespace BLL.Core.BLL_Core.Repository
{
    public class BLLFactory : IBLLFactory
    {
        private readonly DalFactory _dalFactory;
        private IProductBLL _product;
        private IBrandBLL _brand;
        private ICountryBLL _country;
        private INumberStringBLL _numberString;
        private ISubcategoryBLL _subcategory;
        private ICategoryBLL _category;
        private IUserBLL _user;
        private IOrderBLL _order;
        private ICityBLL _city;
        private IRegionBLL _region;
        public BLLFactory()
        {
            _dalFactory = new DalFactory(new DbFactory());
        }

        public IProductBLL ProductBll => _product ?? (_product = new ProductBLL(_dalFactory));
        public IBrandBLL BrandBll => _brand ?? (_brand = new BrandBLL(_dalFactory));
        public ICountryBLL CountryBll => _country ?? (_country = new CountryBLL(_dalFactory));
        public INumberStringBLL NumberStringBll => _numberString ?? (_numberString = new NumberStringBLL(_dalFactory));
        public ISubcategoryBLL SubcategoryBll => _subcategory ?? (_subcategory = new SubcategoryBLL(_dalFactory));
        public ICategoryBLL CategoryBll => _category ?? (_category = new CategoryBLL(_dalFactory));
        public IUserBLL UserBll => _user ?? (_user = new UserBLL(_dalFactory));
        public IOrderBLL OrderBll => _order ?? (_order = new OrderBLL(_dalFactory));
        public ICityBLL CityBll => _city ?? (_city = new CityBLL(_dalFactory));
        public IRegionBLL RegionBll => _region ?? (_region = new RegionBLL(_dalFactory));
    }
}