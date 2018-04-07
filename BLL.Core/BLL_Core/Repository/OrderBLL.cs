using System.Collections.Generic;
using BLL.Core.BLL_Core.Interface;
using DAL.Core.DAL_Core;
using DAL.Core.ModelDTO;

namespace BLL.Core.BLL_Core.Repository
{
    public class OrderBLL : IOrderBLL
    {
        private readonly DalFactory _dalFactory;

        public OrderBLL(DalFactory dalFactory)
        {
            _dalFactory = dalFactory;
        }

        public List<OrderDto> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Add(OrderDto order)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(List<OrderDto> data)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }

}