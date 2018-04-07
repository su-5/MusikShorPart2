using System;
using System.Collections.Generic;

namespace DAL.Core.ModelDTO
{
    public class OrderDto
    {

        public int Id { get; set; }
        public string UserId { get; set; }
        public int Amount { get; set; }
        public int TypeOrdersId { get; set; }
        public int AddressDeliveryId { get; set; }
        public DateTime DateShapingOrders { get; set; }
        public DateTime? DatePurchase { get; set; }
        public DateTime? DateCancel { get; set; }
        public decimal OrderSum { get; set; }
        public int PaymentRequisitesId { get; set; }
        public int NumberOrder { get; set; }
        public List<OrderListProduct> OrderListProducts { get; set; }
    }

    public class OrderListProduct
    {
        public int ProductId { get; set; }
        public int AmountProduct { get; set; }
    }
}
