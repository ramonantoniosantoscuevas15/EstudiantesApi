namespace EstudiantesApi.Entidades
{
    public class CursoEstudiante
    {
        public int cursoId { get; set; }
        public int estudianteId { get; set; }
        public Curso curso { get; set; } = null!;
        public Estudiante estudiante { get; set; } = null!;
    }
}
