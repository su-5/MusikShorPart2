using System.Collections.Generic;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Interface
{
    public interface INumberStringBLL
    {
        List<NumberStringDTO> GetAll();
        void Add(NumberStringDTO numberString);
        void Edit(List<NumberStringDTO> data);
        void Delete(int id);
    }
}