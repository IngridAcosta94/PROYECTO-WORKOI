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
        [Required(ErrorMessage = "El Nombre es requerido.")]
		public string Nombre { get; set; }
		[Display(Name = "Direccion")]
		[Required(ErrorMessage = "La dirección es requerida.")]
		public string Direccion { get; set; }
		[Display(Name = "Correo")]
		[EmailAddress(ErrorMessage = " Debe de ser un correo valido")]
		public string Correo { get; set; }
		[Display(Name = "Telefono")]
		[Required(ErrorMessage = "El teléfono es requerido.")]
		public string Telefono { get; set; }
		//public string PhotoEmpresa { get; set; }
		
		public ICollection<Orden> Ordenes { get; set; }

		[ForeignKey("Cuenta")]
		public int CuentaId { get; set; }
		[Display(Name = "Id")]
		public Cuenta Cuenta { get; set; }


	}
}
