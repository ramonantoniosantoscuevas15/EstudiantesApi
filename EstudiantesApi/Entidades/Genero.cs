using System.ComponentModel.DataAnnotations;

namespace EstudiantesApi.Entidades
{
    public class Genero
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public required string Tipo { get; set; }
    }
}
