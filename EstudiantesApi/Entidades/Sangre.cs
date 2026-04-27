using System.ComponentModel.DataAnnotations;

namespace EstudiantesApi.Entidades
{
    public class Sangre
    {
        public int Id { get; set; }
        [Required]
        [StringLength(4)]
        public required string Tipo { get; set; } 
    }
}
