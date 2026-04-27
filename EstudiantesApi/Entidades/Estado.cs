using System.ComponentModel.DataAnnotations;

namespace EstudiantesApi.Entidades
{
    public class Estado
    {
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public required string Tipo { get; set; }
    }
}
