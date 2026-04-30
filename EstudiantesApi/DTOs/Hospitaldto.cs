using System.ComponentModel.DataAnnotations;

namespace EstudiantesApi.DTOs
{
    public class Hospitaldto
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
    }
}
