using System;
using System.ComponentModel.DataAnnotations;

namespace ArchitectureClean.App.BusinessLogic.Entities
{
	public partial class TestEntityBusiness 
	{
		[Required(AllowEmptyStrings = false, ErrorMessage = "The Id field is required")]
		public long Id { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "The Name field is required")]
		public string Name { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "The Removed field is required")]
		public bool Removed { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "The IdUserCreation field is required")]
		[StringLength(50, ErrorMessage = "The IdUserCreation field must have a maximum of 50 characters")]
		public string IdUserCreation { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "The IpUserCreation field is required")]
		[StringLength(50, ErrorMessage = "The IpUserCreation field must have a maximum of 50 characters")]
		public string IpUserCreation { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "The CreationDate field is required")]
		public DateTime CreationDate { get; set; }

		public DateTime? ModificationDate { get; set; }

		[StringLength(50, ErrorMessage = "The IdUserModifier field must have a maximum of 50 characters")]
		public string IdUserModifier { get; set; }

		[StringLength(50, ErrorMessage = "The IpUserModifier field must have a maximum of 50 characters")]
		public string IpUserModifier { get; set; }
	}
}