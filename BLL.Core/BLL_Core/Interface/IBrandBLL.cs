using System.Collections.Generic;
using DAL.Core;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Interface
{
    public interface IBrandBLL
    {
        List<BrandDTO> GetAll();
        void Add(BrandDTO brand);
        void Edit(List<BrandDTO> data);
        void Delete(BrandDTO id);
    }
}