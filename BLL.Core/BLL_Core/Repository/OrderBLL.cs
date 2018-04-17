using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Threading.Extensions;
using AutoMapper;
using BLL.Core.BLL_Core.Ex;
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

        public int SavePreOrder(OrderDto data)
        {
            using (var transaction = _dalFactory.DbContext.Database.BeginTransaction())
            {
                try
                {
                    var allOrder = _dalFactory.Order.GetAll().ToList();
                    if (!allOrder.Any())
                    {
                        data.NumberOrder = 1 + DateTime.Now.Day + DateTime.Now.Year;
                    }
                    else
                    {
                        data.NumberOrder = (allOrder.Max(v => v.Id)) + (1) + DateTime.Now.Day + DateTime.Now.Year;
                    }

                    var result = Mapper.Map<OrderDto, Order>(data);
                    result.UserId = _dalFactory.User.GetAll().FirstOrDefault(e => e.Email == data.UserEmail)?.Id;
                    result.AddressDeliveryId = null;
                    result.PaymentRequisitesId = null;
                    var orderId = _dalFactory.Order.AddWithReturn(result).Id;
                    var prodicts = Mapper.Map<List<OrderListProduct>, List<OrdersProduct>>(data.OrderListProducts);
                    foreach (var value in prodicts)
                    {
                        value.OrdersId = orderId;
                        _dalFactory.OrdersProduct.Add(value);
                    }

                    CalculateProduct(prodicts);
                    transaction.Commit();
                    return result.NumberOrder;
                }
                catch (Exception ex) // блок сработает в случае ошибки выполнения кода выше который в блоке try!!!
                {
                    transaction.Rollback();
                }

                return 0;
            }
        }

        public void Order(PaidOrderDTO data)
        {
            var order = _dalFactory.Order.GetAll().FirstOrDefault(f => f.NumberOrder == data.NumberOrder);
            string cityId = data.AddressDelivery.City.Id.ToString();
            string paymentSystem = data.PaymentRequisite.PaymentSystems.Id.ToString();
            if (order != null)
            {
                order.TypeOrdersId = 2;
                order.DatePurchase = DateTime.Now;
                order.PaymentRequisite = new PaymentRequisite
                {
                    PaymentSystemsId = Convert.ToInt32(paymentSystem),
                    DateAction = DateTime.Now,
                    NumberAccount = data.PaymentRequisite.NumberAccount,
                    NumberCard = data.PaymentRequisite.NumberCard,
                    UserName = data.PaymentRequisite.UserName
                };
                order.AddressDelivery = new AddressDelivery
                {
                    CityId = Convert.ToInt32(cityId),
                    House = data.AddressDelivery.House,
                    Flat = data.AddressDelivery.Flat,
                    Street = data.AddressDelivery.Street
                };
            }

            if (order != null)
            {
                _dalFactory.Order.UpdateVoid(order, order.Id);
            }
        }
        // пересчет продуктов исходя из заказа
        public void CalculateProduct(List<OrdersProduct> prodгсList)
        {
            foreach (OrdersProduct val in prodгсList)
            {
                var product = _dalFactory.Product.GetById(val.ProductId);
                product.NumberProduct = product.NumberProduct - val.AmountProduct;
                _dalFactory.Product.UpdateVoid(product, product.Id);
            }
        }
    }

}