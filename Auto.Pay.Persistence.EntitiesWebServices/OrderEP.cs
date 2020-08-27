using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auto.Pay.Persistence.Entities
{
	[Table("ORDERS")]
	public partial class OrderEP : IEntityPersistence
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ID")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "The Id field is required")]
		public long Id { get; set; }

		[Column("PaymentReferenceId")]
		[ForeignKey("PaymentReference")]

		public long PaymentReferenceId { get; set; }

		public PaymentReferenceEP PaymentReference { get; set; }

		[Column("OrderCredibancoId")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "The Removed field is required")]
		public string OrderCredibancoId { get; set; }

		[Column("CreationDate")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "The CreationDate field is required")]
		public DateTime CreationDate { get; set; }

		[Column("Amount")]
		public decimal Amount { get; set; }


		[Column("Currency")]
		public string Currency { get; set; }


		[Column("Language")]
		public string Language { get; set; }


		[Column("ReturnUrl")]
		public string ReturnUrl { get; set; }

		[Column("FailUrl")]
		public string FailUrl { get; set; }

		[Column("Description")]
		public string Description { get; set; }

		[Column("PageView")]
		public string PageView { get; set; }

		[Column("ClientId")]
		public string ClientId { get; set; }

		[Column("MerchantLogin")]
		public string MerchantLogin { get; set; }

		[Column("JsonParams")]
		public string JsonParams { get; set; }

		[Column("SessionTimeoutSecs")]
		public DateTime? SessionTimeoutSecs { get; set; }

		[Column("ExpirationDate")]
		public DateTime ExpirationDate { get; set; }

		[Column("Features")]
		public string Features { get; set; }

		[Column("PaymentFromUrlCredibanco")]
		public string PaymentFromUrlCredibanco { get; set; }

		[Column("PaymentStatus")]
		public int PaymentStatus { get; set; }

		[Column("DescriptionPaymentStatus")]
		public string DescriptionPaymentStatus { get; set; }

    }
}