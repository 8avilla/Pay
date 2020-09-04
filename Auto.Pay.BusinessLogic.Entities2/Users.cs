using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auto.Pay.BusinessLogic.Entities
{
    [Table("Users")]
    public partial class Users : EntityBusinessLogic
    {
        #region Llave primaria

        [Key]
        [Column("Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Id  es requerido")]
        [StringLength(250, ErrorMessage = "El campo Id  no debe tener mas de 250 caracteres")]
        public virtual string Id { get; set; }


        #endregion

        #region Columnas normales

        [Column("Nombre")]
        [StringLength(2147483647, ErrorMessage = "El campo Nombre no debe tener mas de 2147483647 caracteres")]
        public virtual string Nombre { get; set; }

        [Column("Apellido")]
        [StringLength(2147483647, ErrorMessage = "El campo Apellido no debe tener mas de 2147483647 caracteres")]
        public virtual string Apellido { get; set; }

        [Column("CorreoElectronico")]
        [StringLength(2147483647, ErrorMessage = "El campo CorreoElectronico no debe tener mas de 2147483647 caracteres")]
        public virtual string Correoelectronico { get; set; }

        [Column("UrlFoto")]
        [StringLength(2147483647, ErrorMessage = "El campo UrlFoto no debe tener mas de 2147483647 caracteres")]
        public virtual string Urlfoto { get; set; }

        [Column("IdUsuarioCreador")]
        [StringLength(250, ErrorMessage = "El campo IdUsuarioCreador no debe tener mas de 250 caracteres")]
        public virtual string Idusuariocreador { get; set; }

        [Column("USeRname")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo UserName es requerido")]
        [StringLength(2147483647, ErrorMessage = "El campo UserName no debe tener mas de 2147483647 caracteres")]
        public virtual string Username { get; set; }

        [Column("PasswordHash")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo PasswordHash es requerido")]
        [StringLength(2147483647, ErrorMessage = "El campo PasswordHash no debe tener mas de 2147483647 caracteres")]
        public virtual string Passwordhash { get; set; }

        [Column("CorreoElectronicoConfirmado")]
        [StringLength(2147483647, ErrorMessage = "El campo CorreoElectronicoConfirmado no debe tener mas de 2147483647 caracteres")]
        public virtual string Correoelectronicoconfirmado { get; set; }

        [Column("NumeroTelefonico")]
        public virtual int? Numerotelefonico { get; set; }

        [Column("FechaRegistro")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo FechaRegistro es requerido")]
        public virtual DateTime Fecharegistro { get; set; }

        [Column("Delete")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Delete es requerido")]
        public virtual bool Eliminado { get; set; }

        [Column("NumeroTelefonicoConfirmado")]
        public virtual int? Numerotelefonicoconfirmado { get; set; }

        #endregion

        #region Columnas referenciales


        #endregion
    }
}
