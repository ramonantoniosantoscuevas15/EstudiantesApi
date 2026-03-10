using System.ComponentModel.DataAnnotations;

namespace EstudiantesApi.Entidades
{
    public class Curso
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo{0} es obligatorio.")]
        [StringLength(10, ErrorMessage = "El campo{0} debe tener {1} caracteres o menos")]
        public required string Nombre { get; set; } = null!;
    }
}
