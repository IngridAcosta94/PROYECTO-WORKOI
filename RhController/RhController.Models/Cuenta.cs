using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RhController.Models
{
	public class Cuenta : BaseEntity
	{
		
		public string Nombre { get; set; }
		public string Usuario { get; set; }
		public string Contrasenia { get; set; }
        public string Correo { get; set; }

		public Empresa Empresa { get; set; }




	}
}
