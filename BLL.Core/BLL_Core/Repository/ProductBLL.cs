using BLL.Core.BLL_Core.Interface;
using DAL.Core.DAL_Core;

namespace BLL.Core.BLL_Core.Repository
{
    public class ProductBLL : IProductBLL
    {
        private readonly DalFactory _dalFactory;

        public ProductBLL(DalFactory dalFactory)
        {
            _dalFactory = dalFactory;
        }
    }
}