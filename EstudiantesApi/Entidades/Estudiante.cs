using System.ComponentModel.DataAnnotations;

namespace EstudiantesApi.Entidades
{
    public class Estudiante
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo{0} del estudiante es obligatorio.")]
        [StringLength(10, ErrorMessage ="El campo{0} debe tener {1} caracteres o menos")]
        public required string  Nombre { get; set; } = null!;
        [Required(ErrorMessage = "El campo{0} del estudiante es obligatorio.")]
        [StringLength(10, ErrorMessage = "El campo{0} debe tener {1} caracteres o menos")]
        public required string Apellido { get; set; } = null!;
        public string? NombrePadre { get; set; }
        public string? NombreMadre { get; set; }
        public string? NombreTutor { get; set; }
        [Required(ErrorMessage = "El telefono obligatorio.")]
        [Phone( ErrorMessage = "El campo {0} debe ser un número de teléfono válido de 10 dígitos.")]
        public required double Telefono { get; set; }
        [Required(ErrorMessage = "La campo{0} es obligatoria.")]
        [StringLength(100, ErrorMessage = "El campo {0} debe tener {1} caracteres o menos")]
        public required string Direccion { get; set; } = null!;
        public string? Foto { get; set; } 
        public string? ActaNacimiento { get; set; }



    }
}
