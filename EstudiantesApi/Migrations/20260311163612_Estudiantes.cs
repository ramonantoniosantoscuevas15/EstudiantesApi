using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstudiantesApi.Migrations
{
    /// <inheritdoc />
    public partial class Estudiantes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NombrePadre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreMadre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreTutor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<double>(type: "float", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Foto = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ActaNacimiento = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudiantes");
        }
    }
}
