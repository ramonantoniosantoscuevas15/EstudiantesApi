using System.ComponentModel.DataAnnotations;

namespace EstudiantesApi.Entidades
{
    public class Paciente
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public required string Nombre { get; set; }
        public required DateTime FechaNacimiento { get; set; }
        public required int Cedula { get; set; }
        public required string Correo { get; set; }
        public required double Telefono { get; set; }
        [StringLength(150)]
        public required string Direccion { get; set; }
        [StringLength(50)]
        public string? Alegias { get; set; }
        [StringLength(150)]
        public string? NotasMedicas { get; set; }
        [StringLength(50)]
        public required string NombreContacto { get; set; }
        public required double TelefonoContacto { get; set; }
        public List<PacienteGenero> PacienteGeneros { get; set; } = new List<PacienteGenero>();
        public List<PacienteEstado> PacienteEstados { get; set; } = new List<PacienteEstado>();
        public List<PacienteSangre> PacienteSangres { get; set; } = new List<PacienteSangre>();
        public List<DoctorPaciente> DoctorPacientes { get; set; } = new List<DoctorPaciente>();
        public List<HospitalPaciente> HospitalPacientes { get; set; } = new List<HospitalPaciente>();
    }
}
