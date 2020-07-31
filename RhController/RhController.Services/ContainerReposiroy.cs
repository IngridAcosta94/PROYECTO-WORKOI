using Microsoft.EntityFrameworkCore;
using RhController.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RhController.Services
{
	public class ContainerReposiroy : IProyectoRepository
	{




		AppDBContext context;
		public ContainerReposiroy(AppDBContext context)
		{
			this.context = context;
		}


		public IEnumerable<Candidato> GetCandidatosbyOrden(int id)
		{
			throw new NotImplementedException();
		}

		public Empresa GetOrdbyEmpresa(int id)
		{
			throw new NotImplementedException();
		}

		public Orden GetOrden(int id)
		{
			throw new NotImplementedException();
		}

		public int InicioSesion (Cuenta cuenta)
	   {
		   var empresass = context.Empresas.Include(x => x.Cuenta).ToList();
		   int numero = 0;

		   foreach (var item in empresass )
		   {
			   if (cuenta.Contrasenia == item.Cuenta.Contrasenia && cuenta.Correo == item.Cuenta.Correo)
			   {
				   numero = item.Id;
			   }
		   }

		   return numero;

	   }
        




    }
}
