using RhController.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RhController.Services
{
	public interface IProyectoRepository 
	{
        public Empresa GetOrdbyEmpresa(int id);
		public Orden GetOrden (int id);
		public IEnumerable<Candidato> GetCandidatosbyOrden(int id);
		public int InicioSesion(Cuenta cuenta);


	}
}
