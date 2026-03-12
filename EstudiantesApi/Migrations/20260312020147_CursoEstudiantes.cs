using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstudiantesApi.Migrations
{
    /// <inheritdoc />
    public partial class CursoEstudiantes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CursoEstudiantes",
                columns: table => new
                {
                    cursoId = table.Column<int>(type: "int", nullable: false),
                    estudianteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoEstudiantes", x => new { x.cursoId, x.estudianteId });
                    table.ForeignKey(
                        name: "FK_CursoEstudiantes_Cursos_cursoId",
                        column: x => x.cursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoEstudiantes_Estudiantes_estudianteId",
                        column: x => x.estudianteId,
                        principalTable: "Estudiantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursoEstudiantes_estudianteId",
                table: "CursoEstudiantes",
                column: "estudianteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoEstudiantes");
        }
    }
}
