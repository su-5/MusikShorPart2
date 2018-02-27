using BLL.Core.BLL_Core.Interface;
using DAL.Core.DAL_Core;

namespace BLL.Core.BLL_Core.Repository
{
    public class BLLFactory : IBLLFactory
    {
        private readonly DalFactory _dalFactory;
        private IProductBLL _product;
        private IBrandBLL _brand;
        public BLLFactory()
        {
            _dalFactory = new DalFactory(new DbFactory());
        }

        public IProductBLL ProductBll => _product ?? (_product = new ProductBLL(_dalFactory));
        public IBrandBLL BrandBll => _brand ?? (_brand = new BrandBLL(_dalFactory));
    }
}