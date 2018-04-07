using System;
using System.Collections.Generic;
using System.Linq;
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

        public void SavePreOrder(OrderDto data)
        {
            using (var transaction = _dalFactory.DbContext.Database.BeginTransaction())
            {
                try
                {
                    data.NumberOrder = (_dalFactory.Order.GetAll().Max(v => v.Id)) + (1) + DateTime.Now.Day + DateTime.Now.Year;
                    data.UserId = _dalFactory.User.GetAll().FirstOrDefault(e => e.Email == "su-5@tut.by")?.Id;
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }
    }

}