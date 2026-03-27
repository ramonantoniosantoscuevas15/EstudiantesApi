using System.ComponentModel.DataAnnotations;

namespace EstudiantesApi.DTOs
{
    public class Estudiantesdto
    {
        public int Id { get; set; }
        public required string Nombre { get; set; } = null!;
        
        public required string Apellido { get; set; } = null!;
        public string? NombrePadre { get; set; }
        public string? NombreMadre { get; set; }
        public string? NombreTutor { get; set; }
        
        public required double Telefono { get; set; }
        
        public required string Direccion { get; set; }

        public string? Foto { get; set; }

        public string? ActaNacimiento { get; set; }

        public List<Cursodto> Cursos { get; set; } = new List<Cursodto>();


    }
}
