using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EstudiantesApi.DTOs
{
    public class CrearEstudiantesdto
    {
        public required string Nombre { get; set; } = null!;
        [Required]
        [StringLength(10)]
        public required string Apellido { get; set; } = null!;
        public string? NombrePadre { get; set; }
        public string? NombreMadre { get; set; }
        public string? NombreTutor { get; set; }
        [Required]
        [Phone]
        public required double Telefono { get; set; }
        [Required]
        [StringLength(100)]
        public required string Direccion { get; set; }
        
        public IFormFile? Foto { get; set; }
        
        public IFormFile? ActaNacimiento { get; set; }

        //public List<int>? cursoId { get; set; }
    }
}
