using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstudiantesApi.Migrations
{
    /// <inheritdoc />
    public partial class PacienteSangre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PacienteDoctores_Pacientes_PacienteId",
                table: "PacienteDoctores");

            migrationBuilder.CreateTable(
                name: "PacienteSangres",
                columns: table => new
                {
                    SangreId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteSangres", x => new { x.PacienteId, x.SangreId });
                    table.ForeignKey(
                        name: "FK_PacienteSangres_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacienteSangres_Sangres_SangreId",
                        column: x => x.SangreId,
                        principalTable: "Sangres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PacienteSangres_SangreId",
                table: "PacienteSangres",
                column: "SangreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PacienteSangres");

            migrationBuilder.AddForeignKey(
                name: "FK_PacienteDoctores_Pacientes_PacienteId",
                table: "PacienteDoctores",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
