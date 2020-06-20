using System;
using System.Collections.Generic;
using System.Text;

namespace RhController.Models
{
	class Orden
	{
		public int OrdenId { get; set; }
		public string Estatus { get; set; }

		public ICollection<Candidato> Candidatos { get; set; }



	}
}

























