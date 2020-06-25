using System;
using System.Collections.Generic;
using System.Text;

namespace RhController.Models
{
	public class Documentacion
	{
		public int DocumentacionId { get; set; }
		public string Tipo { get; set; }

		public int CandidatoId { get; set; }
		public Candidato Candidato { get; set; }

	}
}
