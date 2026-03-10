using System.ComponentModel.DataAnnotations;

namespace EstudiantesApi.Entidades
{
    public class Estudiante
    {
        int Id { get; set; }
        [Required(ErrorMessage = "El nombre del estudiante es obligatorio.")]
        [Range(2,60, ErrorMessage ="El campo{0} debe tener entre {1} y {2} caracteres")]
        public required string  Nombre { get; set; } = null!;
        [Required(ErrorMessage = "El apellido del estudiante es obligatorio.")]
        [Range(2, 60, ErrorMessage = "El campo{0} debe tener entre {1} y {2} caracteres")]
        public required string Apellido { get; set; } = null!;
        string? NombrePadre { get; set; }
        string? NombreMadre { get; set; }
        string? NombreTutor { get; set; }
        [Required(ErrorMessage = "El telefono obligatorio.")]
        [Range(1000000000, 9999999999, ErrorMessage = "El campo {0} debe ser un número de teléfono válido de 10 dígitos.")]
        public required double Telefono { get; set; }
        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [Range(5, 100, ErrorMessage = "El campo {0} debe tener entre {1} y {2} caracteres.")]
        public required string Direccion { get; set; } = null!;
        string? Foto { get; set; } 
        string? ActaNacimiento { get; set; }



    }
}
