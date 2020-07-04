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
		public string Nombre { get; set; }
		[Display(Name = "Apellido")]
		public string Apellido { get; set; }
		[Display(Name = "Correo")]
		[EmailAddress(ErrorMessage = " Debe de ser un correo valido")]
		public string Correo { get; set; }


		[Display(Name = "Perfil")]
		[Required(ErrorMessage = "El perfil es requerido.")]
		[ForeignKey("Perfil")]
		public int PerfilId { get; set; }
		[Display(Name = "Id")]
		public Perfil Perfil { get; set; }












	}
}
