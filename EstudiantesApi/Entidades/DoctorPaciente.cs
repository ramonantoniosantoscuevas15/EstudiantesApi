namespace EstudiantesApi.Entidades
{
    public class DoctorPaciente
    {
        public int DoctorId { get; set; }
        public int PacienteId { get; set; }
        public Doctor Doctor { get; set; } = null!;
        public Paciente Paciente { get; set; }= null!;
    }
}
