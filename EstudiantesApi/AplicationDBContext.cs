using EstudiantesApi.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EstudiantesApi
{
    public class AplicationDBContext : DbContext
    {
        public AplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Curso>Cursos { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }

        protected AplicationDBContext()
        {
        }
    }
}
