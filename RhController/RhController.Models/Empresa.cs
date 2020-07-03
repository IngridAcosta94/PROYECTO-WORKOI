using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RhController.Models
{
	public class Empresa : BaseEntity
	{
		
		[Display(Name = "Nombre")]
		public string Nombre { get; set; }
        public string Direccion { get; set; }
		[Display(Name = "Correo")]
		[EmailAddress(ErrorMessage = " Debe de ser un correo valido")]
		public string Correo { get; set; }
		[Display(Name = "Telefono")]
		public string Telefono { get; set; }

		[Display(Name = "Orden")]
		[Required(ErrorMessage = "La Orden es requerida.")]
		[ForeignKey("Orden")]
		public ICollection<Orden> Ordenes { get; set; }

		[Display(Name = "Perfil")]
		[Required(ErrorMessage = "El perfil es requerido.")]
		[ForeignKey("Perfil")]
		public int PerfilId { get; set; }


	}
}
