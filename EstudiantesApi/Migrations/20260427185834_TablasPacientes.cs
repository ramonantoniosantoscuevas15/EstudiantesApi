using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstudiantesApi.Migrations
{
    /// <inheritdoc />
    public partial class TablasPacientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cedula = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<double>(type: "float", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Alegias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NotasMedicas = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    NombreContacto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TelefonoContacto = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PacienteDoctores",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    DoctorAsignado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteDoctores", x => new { x.PacienteId, x.DoctorId });
                    table.ForeignKey(
                        name: "FK_PacienteDoctores_Dotores_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Dotores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacienteDoctores_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacienteEstados",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteEstados", x => new { x.PacienteId, x.EstadoId });
                    table.ForeignKey(
                        name: "FK_PacienteEstados_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacienteEstados_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacienteGeneros",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteGeneros", x => new { x.PacienteId, x.GeneroId });
                    table.ForeignKey(
                        name: "FK_PacienteGeneros_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacienteGeneros_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacienteHospitales",
                columns: table => new
                {
                    HospitalId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    CentroMedico = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteHospitales", x => new { x.PacienteId, x.HospitalId });
                    table.ForeignKey(
                        name: "FK_PacienteHospitales_Hospitales_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacienteHospitales_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PacienteDoctores_DoctorId",
                table: "PacienteDoctores",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteEstados_EstadoId",
                table: "PacienteEstados",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteGeneros_GeneroId",
                table: "PacienteGeneros",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteHospitales_HospitalId",
                table: "PacienteHospitales",
                column: "HospitalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PacienteDoctores");

            migrationBuilder.DropTable(
                name: "PacienteEstados");

            migrationBuilder.DropTable(
                name: "PacienteGeneros");

            migrationBuilder.DropTable(
                name: "PacienteHospitales");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
