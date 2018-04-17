namespace DAL.Core.ModelDTO
{
    public class PaymentRequisiteDTO
    {
        public int Id { get; set; }
        public dynamic PaymentSystems { get; set; }
        public string NumberAccount { get; set; }
        public string NumberCard { get; set; }
        public System.DateTime DateAction { get; set; }
        public string UserName { get; set; }

    }
}