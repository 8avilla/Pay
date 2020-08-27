using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auto.Pay.Persistence.Entities
{
    [Table("PaymentReference")]
	public class PaymentReferenceEP : IEntityPersistence
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ID")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "The Id field is required")]
		public long Id { get; set; }

		[Column("PaymentReferenceCode")]
		public string PaymentReferenceCode { get; set; }

		[Column("CreationDate")]
		public DateTime CreationDate { get; set; }

		[Column("Amount")]
		public decimal Amount { get; set; }

	}
}
