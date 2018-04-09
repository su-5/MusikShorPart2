using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Interface
{
    public interface IOrderBLL
    {       
        void SavePreOrder(OrderDto data);
        void Order(OrderDto data);
    }
}