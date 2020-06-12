using System;
using System.Collections.Generic;
using System.Text;

namespace RhController.Models
{
	class ReferenciaLab
	{
		public int ReferenciaId { get; set; }
		public string Nombre { get; set; }
		public string Telefono { get; set; }
		public string Direccion { get; set; }
		public string RazonSocial { get; set; }
		public string NombreInformante { get; set; }
		public string PuestoInformante { get; set; }
		public string NombreJefe { get; set; }
		public string PuestoJefe { get; set; }
		public int SueldoInicial { get; set; }
		public string SueldoFinal { get; set; }
		//public Datetime FechaInicLab { get; set; }
		//public Datetime FechaFinLab { get; set; }
		public string MotivoSeparacion { get; set; }
		public string Comentarios { get; set; }

		// referencias
		public int CandidatoId { get; set; }
		public Candidato Candidato { get; set; }

		public int PuestoId { get; set; }
		public PuestoAnterior PuestoAnterior { get; set; }
	}
}
