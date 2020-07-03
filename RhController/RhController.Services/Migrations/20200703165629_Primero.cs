using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RhController.Services.Migrations
{
    public partial class Primero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documentaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAT = table.Column<DateTime>(nullable: false),
                    UpdatedAT = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentaciones", x => x.Id);
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
                });

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
                    Nombre = table.Column<string>(nullable: true),
                    PermisoId = table.Column<int>(nullable: false)
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
                    Nombre = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puestos", x => x.Id);
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
                name: "Asesores",
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
                    table.PrimaryKey("PK_Asesores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asesores_Perfiles_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Contraseña = table.Column<string>(nullable: true),
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
                    FechaNac = table.Column<DateTime>(nullable: false),
                    EstadoCivil = table.Column<bool>(nullable: false),
                    PhotoCandidato = table.Column<string>(nullable: true),
                    Genero = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    NacionalidadId = table.Column<int>(nullable: false),
                    OrdenId = table.Column<int>(nullable: false),
                    DocumentoId = table.Column<int>(nullable: false),
                    DcumentacionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidatos_Documentaciones_DcumentacionId",
                        column: x => x.DcumentacionId,
                        principalTable: "Documentaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Referencias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAT = table.Column<DateTime>(nullable: false),
                    UpdatedAT = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    ReferenciaId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    RazonSocial = table.Column<string>(nullable: true),
                    NombreInformante = table.Column<string>(nullable: true),
                    PuestoInformante = table.Column<string>(nullable: true),
                    NombreJefe = table.Column<string>(nullable: true),
                    PuestoJefe = table.Column<string>(nullable: true),
                    SueldoInicial = table.Column<int>(nullable: false),
                    SueldoFinal = table.Column<string>(nullable: true),
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
                name: "IX_Asesores_PerfilId",
                table: "Asesores",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_DcumentacionId",
                table: "Candidatos",
                column: "DcumentacionId");

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
                name: "Asesores");

            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Referencias");

            migrationBuilder.DropTable(
                name: "Perfiles");

            migrationBuilder.DropTable(
                name: "Candidatos");

            migrationBuilder.DropTable(
                name: "Puestos");

            migrationBuilder.DropTable(
                name: "Documentaciones");

            migrationBuilder.DropTable(
                name: "Nacionalidades");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
