namespace EstudiantesApi.DTOs
{
    public class EstudiantePutgetdto
    {
        public Estudiantesdto Estudiante { get; set; } = null!;
        public List<Cursodto> cursoSeleccionado { get; set; } = new List<Cursodto>();
        public List<Cursodto> cursoNoSeleccionado { get; set; } = new List<Cursodto>();
    }
}
