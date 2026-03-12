using EstudiantesApi.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EstudiantesApi
{
    public class AplicationDBContext : DbContext
    {
        public AplicationDBContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CursoEstudiante>().HasKey(ce=> new { ce.cursoId, ce.estudianteId });
        }

        public DbSet<Curso>Cursos { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<CursoEstudiante> CursoEstudiantes { get; set; }

        protected AplicationDBContext()
        {
        }
    }
}
