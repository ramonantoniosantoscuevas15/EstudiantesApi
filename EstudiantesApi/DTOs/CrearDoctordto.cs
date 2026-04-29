using System.ComponentModel.DataAnnotations;

namespace EstudiantesApi.DTOs
{
    public class CrearDoctordto
    {
        
        public required string Nombre { get; set; }
        
        public required string Especialidad { get; set; }
    }
}
