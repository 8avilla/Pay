namespace Auto.Pay.BusinessLogic.Entities
{
    public class ResponseRegisterOrderCredibancoEBL : ResponsePayEBL
    {
        public string OrderId { get; set; }
        public string FormUrl { get; set; }
        public long Amount { get; set; }
    }
}
