using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RhUI.Models.DB
{
    public partial class PROYECTOWORKContext : DbContext
    {
        public PROYECTOWORKContext()
        {
        }

        public PROYECTOWORKContext(DbContextOptions<PROYECTOWORKContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidatos> Candidatos { get; set; }
        public virtual DbSet<Cuentas> Cuentas { get; set; }
        public virtual DbSet<Documentaciones> Documentaciones { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<Nacionalidades> Nacionalidades { get; set; }
        public virtual DbSet<Ordenes> Ordenes { get; set; }
        public virtual DbSet<Perfiles> Perfiles { get; set; }
        public virtual DbSet<Puestos> Puestos { get; set; }
        public virtual DbSet<Referencias> Referencias { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=PROYECTOWORK;Trusted_Connection=True;user id=sa;password=Ingrid1234;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Candidatos>(entity =>
            {
                entity.HasIndex(e => e.DcumentacionId);

                entity.HasIndex(e => e.NacionalidadId);

                entity.HasIndex(e => e.OrdenId);

                entity.Property(e => e.CreatedAt).HasColumnName("CreatedAT");

                entity.Property(e => e.UpdatedAt).HasColumnName("UpdatedAT");

                entity.HasOne(d => d.Dcumentacion)
                    .WithMany(p => p.Candidatos)
                    .HasForeignKey(d => d.DcumentacionId);

                entity.HasOne(d => d.Nacionalidad)
                    .WithMany(p => p.Candidatos)
                    .HasForeignKey(d => d.NacionalidadId);

                entity.HasOne(d => d.Orden)
                    .WithMany(p => p.Candidatos)
                    .HasForeignKey(d => d.OrdenId);
            });

            modelBuilder.Entity<Cuentas>(entity =>
            {
                entity.HasIndex(e => e.PerfilId);

                entity.Property(e => e.CreatedAt).HasColumnName("CreatedAT");

                entity.Property(e => e.UpdatedAt).HasColumnName("UpdatedAT");

                entity.HasOne(d => d.Perfil)
                    .WithMany(p => p.Cuentas)
                    .HasForeignKey(d => d.PerfilId);
            });

            modelBuilder.Entity<Documentaciones>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnName("CreatedAT");

                entity.Property(e => e.UpdatedAt).HasColumnName("UpdatedAT");
            });

            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.HasIndex(e => e.PerfilId);

                entity.Property(e => e.CreatedAt).HasColumnName("CreatedAT");

                entity.Property(e => e.UpdatedAt).HasColumnName("UpdatedAT");

                entity.HasOne(d => d.Perfil)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.PerfilId);
            });

            modelBuilder.Entity<Empresas>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnName("CreatedAT");

                entity.Property(e => e.UpdatedAt).HasColumnName("UpdatedAT");
            });

            modelBuilder.Entity<Nacionalidades>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnName("CreatedAT");

                entity.Property(e => e.UpdatedAt).HasColumnName("UpdatedAT");
            });

            modelBuilder.Entity<Ordenes>(entity =>
            {
                entity.HasIndex(e => e.EmpresaId);

                entity.Property(e => e.CreatedAt).HasColumnName("CreatedAT");

                entity.Property(e => e.UpdatedAt).HasColumnName("UpdatedAT");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Ordenes)
                    .HasForeignKey(d => d.EmpresaId);
            });

            modelBuilder.Entity<Perfiles>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnName("CreatedAT");

                entity.Property(e => e.UpdatedAt).HasColumnName("UpdatedAT");
            });

            modelBuilder.Entity<Puestos>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnName("CreatedAT");

                entity.Property(e => e.UpdatedAt).HasColumnName("UpdatedAT");
            });

            modelBuilder.Entity<Referencias>(entity =>
            {
                entity.HasIndex(e => e.CandidatoId);

                entity.HasIndex(e => e.PuestoId);

                entity.Property(e => e.CreatedAt).HasColumnName("CreatedAT");

                entity.Property(e => e.UpdatedAt).HasColumnName("UpdatedAT");

                entity.HasOne(d => d.Candidato)
                    .WithMany(p => p.Referencias)
                    .HasForeignKey(d => d.CandidatoId);

                entity.HasOne(d => d.Puesto)
                    .WithMany(p => p.Referencias)
                    .HasForeignKey(d => d.PuestoId);
            });*/

            OnModelCreatingPartial(modelBuilder);
            modelBuilder.Query<LoginByUsernamePassword>();

             
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

		[Obsolete]
		public async Task<List<LoginByUsernamePassword>> LoginByUsernamePasswordAsync(string usernameVal, string passwordVal)
		{
            List<LoginByUsernamePassword> lst = new List<LoginByUsernamePassword>();
			try
			{
                SqlParameter usernameParam = new SqlParameter("@username", usernameVal ?? (object)DBNull.Value);
                SqlParameter passwordParam = new SqlParameter("@password", passwordVal ?? (object)DBNull.Value);

                string sqlQuery = "EXEC [dbo].[LoginByUsernamePassword" + "@username, @password";
                lst = await this.Query<LoginByUsernamePassword>().FromSql(sqlQuery, usernameParam, passwordParam).ToListAsync();
            }
            catch(Exception ex)
			{
                throw ex;
			}
            return lst;
		}
    }
}
