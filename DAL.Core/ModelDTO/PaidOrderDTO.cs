namespace DAL.Core.ModelDTO
{
    public class PaidOrderDTO
    {
        public AddressDeliveryDTO AddressDelivery { get; set; }
        public int NumberOrder { get; set; }
        public PaymentRequisiteDTO PaymentRequisite { get; set; }
    }
}
