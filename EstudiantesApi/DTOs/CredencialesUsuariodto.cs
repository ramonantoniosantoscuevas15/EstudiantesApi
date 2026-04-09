using System.ComponentModel.DataAnnotations;

namespace EstudiantesApi.DTOs
{
    public class CredencialesUsuariodto
    {
        [EmailAddress]
        [Required]
         public required string Email { get; set; }
        [Required]
         public required string Password { get; set; }
    }
}
