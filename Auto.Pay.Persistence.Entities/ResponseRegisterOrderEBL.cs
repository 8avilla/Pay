namespace Auto.Pay.BusinessLogic.Entities
{
    public class ResponseRegisterOrderEBL : ResponsePayEBL
    {
        public string OrderId { get; set; }
        public string FormUrl { get; set; }
    }
}
