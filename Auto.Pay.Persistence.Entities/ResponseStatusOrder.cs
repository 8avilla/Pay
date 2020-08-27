namespace Auto.Pay.BusinessLogic.Entities
{
    public class ResponseStatusOrderEBL : ResponsePayEBL
    {
        public string OrderNumber { get; set; }
        public string OrderStatus { get; set; }
        public string ActionCode { get; set; }
        public string ActionCodeDescription { get; set; }
        public new string ErrorCode { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string Date { get; set; }
        public string OrderDescription { get; set; }
    }
}
