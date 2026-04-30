using System.ComponentModel.DataAnnotations;

namespace EstudiantesApi.DTOs
{
    public class Pacientedto
    {
        public int Id { get; set; }
        
        public required string Nombre { get; set; }
        public required DateTime FechaNacimiento { get; set; }
        public required int Cedula { get; set; }
        public required string Correo { get; set; }
        public required double Telefono { get; set; }
        
        public required string Direccion { get; set; }
        
        public string? Alegias { get; set; }
        
        public string? NotasMedicas { get; set; }
        
        public required string NombreContacto { get; set; }
        public required double TelefonoContacto { get; set; }
    }
}
