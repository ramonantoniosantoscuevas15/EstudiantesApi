using System.ComponentModel.DataAnnotations;

namespace EstudiantesApi.Entidades
{
    public class Hospital
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public required string Nombre { get; set; }
    }
}
