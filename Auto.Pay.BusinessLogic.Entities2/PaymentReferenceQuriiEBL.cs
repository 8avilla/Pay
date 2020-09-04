using System;

namespace Auto.Pay.BusinessLogic.Entities
{
    public class PaymentReferenceQuriiEBL : EntityBusinessLogic
	{
		public string Guid { get; set; }
		public string Code { get; set; }

		public DateTime CreationDate { get; set; }

		public long Amount { get; set; }
		public ContractDetailsQuriiEBL ContractDetails { get; set; }

    }
}
