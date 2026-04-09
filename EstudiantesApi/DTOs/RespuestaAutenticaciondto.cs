namespace EstudiantesApi.DTOs
{
    public class RespuestaAutenticaciondto
    {
        public required string Token { get; set; } 
        public DateTime Expiracion { get; set; }
    }
}
