using System.Collections.Generic;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Interface
{
    public interface ICategoryBLL
    {
        List<CategoryDTO> GetAll();
        void Add(CategoryDTO category);
        void Edit(List<CategoryDTO> data);
        void Delete(int id);
    }
}