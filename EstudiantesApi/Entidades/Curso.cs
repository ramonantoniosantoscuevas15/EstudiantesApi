using System.ComponentModel.DataAnnotations;

namespace EstudiantesApi.Entidades
{
    public class Curso
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo{0} es obligatorio.")]
        [StringLength(20, ErrorMessage = "El campo{0} debe tener {1} caracteres o menos")]
        public required string NombreCurso { get; set; } = null!;
    }
}
