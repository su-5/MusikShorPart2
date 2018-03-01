using System.Collections.Generic;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Interface
{
    public interface ISubcategoryBLL
    {
        List<SubcategoryDTO> GetAll();
        void Add(SubcategoryDTO subcategory);
        void Edit(List<SubcategoryDTO> data);
        void Delete(int id);

    }
}