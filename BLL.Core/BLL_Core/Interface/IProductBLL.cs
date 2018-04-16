using System.Collections.Generic;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Interface
{
    public interface IProductBLL
    {
        List<ProductDTO> GetAll();
        void Add(ProductDTO product);
        void Edit(List<ProductDTO> data);
        void Delete(int id);
        List<ProductDTO> GetProductById(int categoryId, int subcategoryId, bool flag);
        List<CartDto> GetAllToCart(List<dynamic> productsListId);
        void CookiesRecordDb(List<dynamic> data);
    }
}