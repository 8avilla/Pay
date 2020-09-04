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
		[Column("Id")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "The Id field is required")]
		public long Id { get; set; }

		[Column("PaymentReferenceCode")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "The PaymentReferenceCode field is required")]
		public string PaymentReferenceCode { get; set; }

		[Column("CreationDate")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "The CreationDate field is required")]
		public DateTime CreationDate { get; set; }

		[Column("Amount")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "The Amount field is required")]
		public long Amount { get; set; }

		[Column("PaymentReferenceObject")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "The PaymentReferenceObject field is required")]
		public string PaymentReferenceObject { get; set; }

	}
}
