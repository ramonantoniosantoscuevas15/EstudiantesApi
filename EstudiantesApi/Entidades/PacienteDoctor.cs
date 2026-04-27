using System.ComponentModel.DataAnnotations;

namespace EstudiantesApi.Entidades
{
    public class PacienteDoctor
    {
        public int DoctorId { get; set; }
        public int PacienteId { get; set; }
        
        [StringLength(50)]
        public required string DoctorAsignado { get; set; }

        public Doctor Doctor { get; set; }= null!;

    }
}
