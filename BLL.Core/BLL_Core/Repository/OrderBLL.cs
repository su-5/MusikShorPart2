using System;
using System.Linq;
using Abp.Threading.Extensions;
using AutoMapper;
using BLL.Core.BLL_Core.Interface;
using DAL.Core;
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
                    data.UserId = _dalFactory.User.GetAll().FirstOrDefault(e => e.Email == "dima-tkachenko@tut.by")?.Id;
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        public void Order(OrderDto data)
        {
            var result = Mapper.Map<OrderDto, Order>(data);
            _dalFactory.Order.Add(result);
        }
    }

}