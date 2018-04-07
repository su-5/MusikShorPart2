using System.Collections.Generic;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Interface
{
    public interface IOrderBLL
    {
        List<OrderDto> GetAll();
        void Add(OrderDto order);
        void Edit(List<OrderDto> data);
        void Delete(int id);
    }
}