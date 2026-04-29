using System.ComponentModel.DataAnnotations;

namespace EstudiantesApi.DTOs
{
    public class Estadodto
    {
        public int Id { get; set; }
        public required string Tipo { get; set; }
    }
}
