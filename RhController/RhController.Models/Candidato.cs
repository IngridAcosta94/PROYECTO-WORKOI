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
		public string Nombre { get; set; }
		[Display(Name = "Apellido")]
		public string Apellido { get; set; }
		public DateTime FechaNac { get; set; }
		[Display(Name = "EstadoCivil")]
		public bool EstadoCivil { get; set;}
		[Display(Name = "Photo")]
		public string PhotoCandidato { get; set; }
		[Display(Name = "Genero")]
		public string Genero { get; set; }
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
		public ICollection<ReferenciaLab> Referencias { get; set; }

		[Display(Name = "Documentacion")]
		[Required(ErrorMessage = "La documentacion es requerida.")]
		[ForeignKey("Documentacion")]
		public int DocumentoId { get; set; }
		public Documentacion Dcumentacion { get; set; }

	}
}
