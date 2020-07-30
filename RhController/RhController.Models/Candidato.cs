using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RhController.Models
{
	public class Candidato : BaseEntity
	{
		
		[Display(Name = "Nombre")]
		[Required(ErrorMessage = "El nombre es requerido.")]
		public string Nombre { get; set; }
		[Display(Name = "Apellido")]
		[Required(ErrorMessage = "El apellido es requerido.")]
		public string Apellido { get; set; }

		//[Display(Name = "Telefono")]
		//[Required(ErrorMessage = "El Telefono es requerido.")]
		//public string Telefono { get; set; }
		[Display(Name = "Curp")]
		[Required(ErrorMessage = "La CURP es requerida.")]
		public string Curp { get; set; }
		[Display(Name = "Direccion")]
		[Required(ErrorMessage = "La dirección es requerida.")]
		public string Direccion { get; set; }
		[Display(Name = "FechaNac")]
		[Required(ErrorMessage = "La Fecha de nacimiento es requerida.")]
		public DateTime FechaNac { get; set; }
		[Display(Name = "EstadoCivil")]
		[Required(ErrorMessage = "El estado civil es requerido.")]
		public string EstadoCivil { get; set;}
		//[Display(Name = "Photo")]
		//public string PhotoCandidato { get; set; }

		[Display(Name = "Genero")]
		public bool Genero { get; set; }
		[Display(Name = "Correo")]
		[EmailAddress(ErrorMessage = " Debe de ser un correo valido")]
		public string Correo { get; set; }


		//referencias
		[Display(Name = "Nacinalidad")]
		[Required(ErrorMessage = "La nacionalidad es requerida.")]
		[ForeignKey("Nacionalidad")]
		public int NacionalidadId { get; set; }
		public Nacionalidad Nacionalidad { get; set; }

		[Display(Name = "Orden")]
		[Required(ErrorMessage = "La Orden es requerida.")]
		[ForeignKey("Orden")]
		public int OrdenId { get; set; }
		public Orden Orden { get; set; }

		public ICollection<ReferenciaLab> Referencias { get; set; }
		//public ICollection<Documentacion> Documentos { get; set; }

	}
}
