﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RhController.Models
{
	public class Cuenta
	{
		public int UsuarioId { get; set; }
		public string Nombre { get; set; }
		public string Contraseña { get; set; }

		public int EmpresaId { get; set; }
		public Empresa Empresa { get; set; }


	}
}