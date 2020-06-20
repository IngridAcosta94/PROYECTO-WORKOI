using System;
using System.Collections.Generic;
using System.Text;

namespace RhController.Models
{
	class Empresa
	{
		public int EmpresaId { get; set; }
		public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
		public string Telefono { get; set; }
		public ICollection<Orden> Ordenes { get; set; }

	}
}
