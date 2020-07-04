

using Microsoft.EntityFrameworkCore;
using RhController.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RhController.Services
{
	public class AppDBContext : DbContext
	{

		public AppDBContext(DbContextOptions<AppDBContext> options) : base (options)
		{

		}

		public DbSet<Empresa> Empresas { get; set; }
		public DbSet<Candidato> Candidatos { get; set; }
		public DbSet<Orden> Ordenes { get; set; }
		public DbSet<Empleado> Empleados { get; set; }
		public DbSet<ReferenciaLab> Referencias { get; set; }
		public DbSet<Nacionalidad> Nacionalidades { get; set; }
		public DbSet<Documentacion> Documentaciones { get; set; }
		public DbSet<Cuenta> Cuentas { get; set; }
		public DbSet<Perfil> Perfiles { get; set; }
		public DbSet<Puesto> Puestos { get; set; }







	}
}
