using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RhController.Models
{
	public class Perfil : BaseEntity
	{
		
		public string Nombre { get; set; }

		[Display(Name = "Permiso")]
		[Required(ErrorMessage = "El permiso es requerido.")]
		[ForeignKey("Permiso")]
		public int PermisoId { get; set; }
		

	}
}
