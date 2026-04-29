namespace EstudiantesApi.Entidades
{
    public class HospitalPaciente
    {
        public int HospitalId { get; set; }
        public int PacienteId { get; set; }
        public Hospital Hospital { get; set; }= null!;
        public Paciente paciente { get; set; }= null!;

    }
}
