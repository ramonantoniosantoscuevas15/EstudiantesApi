using System.ComponentModel.DataAnnotations;

namespace EstudiantesApi.Entidades
{
    public class Cursos
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del curso es obligatorio.")]
        public required string Nombre { get; set; } = null!;
    }
}
