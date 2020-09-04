namespace Auto.Pay.BusinessLogic.Entities
{
    public class ContractDetailsQuriiEBL : EntityBusinessLogic
    {
        public int ContractNumber { get; set; }
        public string ClientName { get; set; }
        public int DocumentType { get; set; }
        public int DocumentNumber { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ProductName { get; set; }
        public double ProductValue { get; set; }
        public int Term { get; set; }
        public double FeedNet { get; set; }
        public double AdministrationFeed { get; set; }
        public double AdministrationFeedIVA { get; set; }
        public double TotalMonthlyFee { get; set; }
        public double AdmissionFee { get; set; }
        public double AdmissionFeeIVA { get; set; }
        public double TotalAdmissionFee { get; set; }
        public double Total { get; set; }
    }
}
