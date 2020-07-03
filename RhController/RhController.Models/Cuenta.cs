using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RhController.Models
{
	public class Cuenta : BaseEntity
	{
		
		public string Nombre { get; set; }
		public string Contraseña { get; set; }

		[Display(Name = "Perfil")]
		[Required(ErrorMessage = "La nacionalidad es requerido")]
		[ForeignKey("Perfil")]
		public int PerfilId { get; set; }
		public Perfil Perfil { get; set; }



	}
}
