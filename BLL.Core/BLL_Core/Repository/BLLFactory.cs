using BLL.Core.BLL_Core.Interface;
using DAL.Core.DAL_Core;

namespace BLL.Core.BLL_Core.Repository
{
    public class BLLFactory : IBLLFactory
    {
        private readonly DalFactory _dalFactory;
        private IProductBLL _product;

        public BLLFactory()
        {
            _dalFactory = new DalFactory(new DbFactory());
        }

        public IProductBLL Product => _product ?? (_product = new ProductBLL(_dalFactory));
    }
}