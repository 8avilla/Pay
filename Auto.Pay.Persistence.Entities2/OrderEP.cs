using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auto.Pay.Persistence.Entities
{
	[Table("Orders")]
	public partial class OrderEP : IEntityPersistence
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("Id")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "The Id field is required")]
		public long Id { get; set; }

		[Column("PaymentReferenceGuid")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "The PaymentReferenceGuid field is required")]
		public string PaymentReferenceGuid { get; set; }


		[Column("OrderCredibancoId")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "The Removed field is required")]
		public string OrderCredibancoId { get; set; }

		[Column("CreationDate")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "The CreationDate field is required")]
		public DateTime CreationDate { get; set; }
		

		[Column("Amount")]
		public long Amount { get; set; }

		
		[Column("AmountPaid")]
		public long AmountPaid { get; set; }


		[Column("PaymentStatus")]
		public int? PaymentStatus { get; set; }

		[Column("DescriptionPaymentStatus")]
		public string DescriptionPaymentStatus { get; set; }

		[Column("RequestRegisterOrderObject")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "The RequestRegisterOrderObject field is required")]
		public string RequestRegisterOrderObject { get; set; }

		[Column("ResponseRegisterOrderObject")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "The ResponseRegisterOrderObject field is required")]
		public string ResponseRegisterOrderObject { get; set; }

		[Column("ResponseOrdersStatusObject")]
		public string ResponseOrdersStatusObject { get; set; }

	}
}