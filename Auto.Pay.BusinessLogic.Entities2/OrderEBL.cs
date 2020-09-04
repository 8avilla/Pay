using System;
using System.Collections.Generic;
using System.Text;

namespace Auto.Pay.BusinessLogic.Entities
{
    public class OrderEBL : EntityBusinessLogic
	{
		public RequestRegisterOrderCredibancoEBL RequestRegisterOrderCredibanco { get; set; }
		public ResponseRegisterOrderCredibancoEBL ResponseRegisterOrderCredibanco { get; set; }
		public ResponseStatusOrderCredibancoEBL ResponseStatusOrderCredibanco { get; set; }
		public long Id { get; set; }
		public string PaymentReferenceGuid { get; set; }
		public string OrderCredibancoId { get; set; }
		public DateTime CreationDate { get; set; }
		public long Amount { get; set; }
		public long AmountPaid { get; set; }
		public int? PaymentStatus { get; set; }
		public string DescriptionPaymentStatus { get; set; }
		public string OrdersObject { get; set; }
		public string OrdersStatusObject { get; set; }
	}
}
