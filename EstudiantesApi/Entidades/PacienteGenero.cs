namespace EstudiantesApi.Entidades
{
    public class PacienteGenero
    {
        public int GeneroId { get; set; }
        public int PacienteId { get; set; }
        public Genero Genero { get; set; } = null!;
        public Paciente Paciente { get; set; }= null!;
        
    }
}
