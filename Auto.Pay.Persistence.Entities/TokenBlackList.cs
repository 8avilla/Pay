using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auto.Pay.BusinessLogic.Entities
{
	[Table("TOKENBLACKLIST")]
	public partial class TokenBlackList : EntityBusinessLogic
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ID")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "El Id es requerido")]
		public long Id { get; set; }

		[Column("TOKEN")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "El Token es requerido")]
		public string Token { get; set; }

		[Column("FECHAREGISTRO")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "El FechaRegistro es requerido")]
		public DateTime FechaRegistro { get; set; }

		[Column("USERNAME")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "El UserName es requerido")]
		[StringLength(50, ErrorMessage = "El UserName no debe tener mas de 50 caracteres")]
		public string UserName { get; set; }

		[Column("ELIMINADO")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "El Delete es requerido")]
		public bool Removed { get; set; }
		public string IdUserCreation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string IpUserCreation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public DateTime CreationDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public DateTime? ModificationDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string IdUserModifier { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string IpUserModifier { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public byte[] Timestamp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	}
}
