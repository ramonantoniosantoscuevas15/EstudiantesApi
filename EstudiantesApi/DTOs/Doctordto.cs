using System.ComponentModel.DataAnnotations;

namespace EstudiantesApi.DTOs
{
    public class Doctordto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;
        
        public  string Especialidad { get; set; } = null!;
    }
}
