using EstudiantesApi.Entidades;
using EstudiantesApi.Utilidades;
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
            modelBuilder.ApplyUtcDateTimeConverter();
            modelBuilder.Entity<CursoEstudiante>().HasKey(ce=> new { ce.cursoId, ce.estudianteId });
            modelBuilder.Entity<PacienteGenero>().HasKey(pg => new { pg.PacienteId, pg.GeneroId });
            modelBuilder.Entity<PacienteEstado>().HasKey(pe => new { pe.PacienteId, pe.EstadoId });
            modelBuilder.Entity<PacienteDoctor>().HasKey(pd => new { pd.PacienteId, pd.DoctorId });
            modelBuilder.Entity<PacienteHospital>().HasKey(ph => new { ph.PacienteId, ph.HospitalId });
            modelBuilder.Entity<DoctorPaciente>().HasKey(dp => new { dp.DoctorId, dp.PacienteId });
            modelBuilder.Entity<HospitalPaciente>().HasKey(hp => new { hp.HospitalId, hp.PacienteId });
        }

        public DbSet<Curso>Cursos { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<CursoEstudiante> CursoEstudiantes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Sangre> Sangres { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Hospital> Hospitales { get; set; }
        public DbSet<Doctor> Dotores { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<PacienteGenero> PacienteGeneros { get; set; }
        public DbSet<PacienteEstado> PacienteEstados { get; set; }
        public DbSet<PacienteDoctor> PacienteDoctores { get; set; }
        public DbSet<PacienteHospital> PacienteHospitales { get; set; }
        public DbSet<DoctorPaciente> DoctorPacientes { get; set; }
        public DbSet<HospitalPaciente> HospitalPacientes { get; set; }

        protected AplicationDBContext()
        {
        }
    }
}
