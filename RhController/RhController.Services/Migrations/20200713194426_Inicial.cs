using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RhController.Services.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nacionalidades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAT = table.Column<DateTime>(nullable: false),
                    UpdatedAT = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nacionalidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAT = table.Column<DateTime>(nullable: false),
                    UpdatedAT = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Puestos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAT = table.Column<DateTime>(nullable: false),
                    UpdatedAT = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puestos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAT = table.Column<DateTime>(nullable: false),
                    UpdatedAT = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Usuario = table.Column<string>(nullable: true),
                    Contraseña = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    PerfilId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuentas_Perfiles_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAT = table.Column<DateTime>(nullable: false),
                    UpdatedAT = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    PerfilId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleados_Perfiles_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAT = table.Column<DateTime>(nullable: false),
                    UpdatedAT = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    PerfilId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresas_Perfiles_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAT = table.Column<DateTime>(nullable: false),
                    UpdatedAT = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    PuestoSolicitado = table.Column<string>(nullable: true),
                    EmpresaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordenes_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAT = table.Column<DateTime>(nullable: false),
                    UpdatedAT = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Curp = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    FechaNac = table.Column<DateTime>(nullable: false),
                    EstadoCivil = table.Column<string>(nullable: true),
                    PhotoCandidato = table.Column<string>(nullable: true),
                    Genero = table.Column<bool>(nullable: false),
                    Correo = table.Column<string>(nullable: true),
                    NacionalidadId = table.Column<int>(nullable: false),
                    OrdenId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidatos_Nacionalidades_NacionalidadId",
                        column: x => x.NacionalidadId,
                        principalTable: "Nacionalidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidatos_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Ordenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documentaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAT = table.Column<DateTime>(nullable: false),
                    UpdatedAT = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Tipo = table.Column<string>(nullable: true),
                    CandidatoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentaciones_Candidatos_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Referencias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAT = table.Column<DateTime>(nullable: false),
                    UpdatedAT = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Telefono1 = table.Column<string>(nullable: true),
                    Telefono2 = table.Column<string>(nullable: true),
                    Telefono3 = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    RazonSocial = table.Column<string>(nullable: true),
                    NombreInformante = table.Column<string>(nullable: true),
                    PuestoInformante = table.Column<string>(nullable: true),
                    NombreJefe = table.Column<string>(nullable: true),
                    PuestoJefe = table.Column<string>(nullable: true),
                    SueldoInicial = table.Column<int>(nullable: false),
                    SueldoFinal = table.Column<int>(nullable: false),
                    FechaInicLab = table.Column<DateTime>(nullable: false),
                    FechaFinLab = table.Column<DateTime>(nullable: false),
                    MotivoSeparacion = table.Column<string>(nullable: true),
                    Comentarios = table.Column<string>(nullable: true),
                    CandidatoId = table.Column<int>(nullable: false),
                    PuestoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referencias_Candidatos_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Referencias_Puestos_PuestoId",
                        column: x => x.PuestoId,
                        principalTable: "Puestos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_NacionalidadId",
                table: "Candidatos",
                column: "NacionalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_OrdenId",
                table: "Candidatos",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_PerfilId",
                table: "Cuentas",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentaciones_CandidatoId",
                table: "Documentaciones",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_PerfilId",
                table: "Empleados",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_PerfilId",
                table: "Empresas",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_EmpresaId",
                table: "Ordenes",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Referencias_CandidatoId",
                table: "Referencias",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Referencias_PuestoId",
                table: "Referencias",
                column: "PuestoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Documentaciones");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Referencias");

            migrationBuilder.DropTable(
                name: "Candidatos");

            migrationBuilder.DropTable(
                name: "Puestos");

            migrationBuilder.DropTable(
                name: "Nacionalidades");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Perfiles");
        }
    }
}
