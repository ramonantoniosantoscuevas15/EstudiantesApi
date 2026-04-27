using System.ComponentModel.DataAnnotations;

namespace EstudiantesApi.Entidades
{
    public class PacienteHospital
    {
        public int HospitalId { get; set; }
        public int PacienteId { get; set; }
        [StringLength(100)]
        public required string CentroMedico { get; set; }

        public Hospital Hospital { get; set; }= null!;
        public Paciente paciente { get; set; }= null!;
    }
}
