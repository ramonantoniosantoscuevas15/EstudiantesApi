namespace EstudiantesApi.DTOs
{
    public class EstudianteDetalledto : Estudiantesdto
    {
        public new List<Cursodto> Cursos { get; set; } = new List<Cursodto>();
    }
}
