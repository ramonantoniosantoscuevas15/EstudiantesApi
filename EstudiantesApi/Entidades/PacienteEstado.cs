namespace EstudiantesApi.Entidades
{
    public class PacienteEstado
    {
        public int EstadoId { get; set; }
        public int PacienteId { get; set; }
        public Estado Estado { get; set; } = null!;
        public Paciente Paciente { get; set; }= null!;
    }
}
