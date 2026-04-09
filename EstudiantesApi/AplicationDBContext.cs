using EstudiantesApi.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EstudiantesApi
{
    public class AplicationDBContext : IdentityDbContext
    {
        public AplicationDBContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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
