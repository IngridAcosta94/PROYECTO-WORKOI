using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RhController.Models
{
	public class Empleado : BaseEntity
	{
		[Display(Name = "Nombre")]
        [Required(ErrorMessage = "El Nombre es requerido.")]
		public string Nombre { get; set; }
		[Display(Name = "Apellido")]
		[Required(ErrorMessage = "El Apellido es requerido.")]
		public string Apellido { get; set; }
		[Display(Name = "Correo")]
		[EmailAddress(ErrorMessage = " Debe de ser un correo valido")]
		public string Correo { get; set; }


		[Display(Name = "PerfilId")]
		[Required(ErrorMessage = "El perfil es requerido.")]
		[ForeignKey("Perfil")]
		public int CuentaId { get; set; }
		[Display(Name = "Id")]
		public Cuenta Cuenta { get; set; }












	}
}
