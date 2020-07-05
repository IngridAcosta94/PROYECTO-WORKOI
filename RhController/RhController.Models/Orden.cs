using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RhController.Models
{
	public class Orden : BaseEntity

	{

		// se retiro el ID y el estatus por que ahora hereda de BaseEntity

		public string  PuestoSolicitado { get; set; }

		public ICollection<Candidato> Candidatos { get; set; }

		[Display(Name = "Empresa")]
		[Required(ErrorMessage = "La empresa es requerida.")]
		[ForeignKey("Empresa")]
		public int EmpresaId { get; set; }
		public  Empresa Empresa { get; set; }



	}
}

























