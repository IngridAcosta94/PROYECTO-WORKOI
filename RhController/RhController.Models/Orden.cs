using System;
using System.Collections.Generic;
using System.Text;

namespace RhController.Models
{
	public class Orden
	{
		public int OrdenId { get; set; }
		public string Estatus { get; set; }

		public ICollection<Candidato> Candidatos { get; set; }

		public int EmpresaId { get; set; }
		public  Empresa Empresa { get; set; }



	}
}

























