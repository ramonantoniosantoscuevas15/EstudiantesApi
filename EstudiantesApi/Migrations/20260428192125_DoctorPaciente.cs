using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstudiantesApi.Migrations
{
    /// <inheritdoc />
    public partial class DoctorPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorPacientes",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorPacientes", x => new { x.DoctorId, x.PacienteId });
                    table.ForeignKey(
                        name: "FK_DoctorPacientes_Dotores_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Dotores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorPacientes_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPacientes_PacienteId",
                table: "DoctorPacientes",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorPacientes");
        }
    }
}
