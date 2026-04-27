namespace EstudiantesApi.Entidades
{
    public class PacienteSangre
    {
        public int SangreId { get; set; }
        public int PacienteId { get; set; }
        public Sangre Sangre { get; set; } = null!;
        public Paciente Paciente { get; set; }= null!;

    }
}
