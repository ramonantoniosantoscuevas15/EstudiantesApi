using System.ComponentModel.DataAnnotations;

namespace EstudiantesApi.Entidades
{
    public class Doctor
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public required string Nombre { get; set; }
        [StringLength(50)]
        public required string Especialidad { get; set; }
    }
}
