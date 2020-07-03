using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RhController.Models
{
	public class ReferenciaLab : BaseEntity

	{
		[Display(Name = "Id")]
		public int ReferenciaId { get; set; }
		[Display(Name = "Nombre")]
		public string Nombre { get; set; }
		[Display(Name = "Telefono")]
		public string Telefono { get; set; }
		[Display(Name = "Direccion")]
		public string Direccion { get; set; }
		[Display(Name = "RazonSocial")]
		public string RazonSocial { get; set; }
		[Display(Name = "NombreInformante")]
		public string NombreInformante { get; set; }
		[Display(Name = "PuestoInformacion")]
		public string PuestoInformante { get; set; }
		[Display(Name = "NombreJefe")]
		public string NombreJefe { get; set; }
		[Display(Name = "PuestoJefe")]
		public string PuestoJefe { get; set; }
		[Display(Name = "SueldoInicial")]
		public int SueldoInicial { get; set; }
		[Display(Name = "SueldoFinal")]
		public string SueldoFinal { get; set; }
		
		public DateTime FechaInicLab { get; set; }
		public DateTime FechaFinLab { get; set; }
		[Display(Name = "Motivo Separacion")]
		public string MotivoSeparacion { get; set; }
		[Display(Name = "Comentarios")]
		public string Comentarios { get; set; }

		// referencias
		[Display(Name = "Candidato")]
		[Required(ErrorMessage = "El candidato es requerido.")]
		[ForeignKey("Candidato")]
		public int CandidatoId { get; set; }
		public Candidato Candidato { get; set; }

		[Display(Name = "Puesto")]
		[Required(ErrorMessage = "El puesto es requerido.")]
		[ForeignKey("Puesto")]
		public int PuestoId { get; set; }
		public Puesto Puesto { get; set; }
	}
}
