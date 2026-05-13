using AutoMapper;
using EstudiantesApi.DTOs;
using EstudiantesApi.Entidades;

namespace EstudiantesApi.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            ConfigurarMappeoEstudiante();
            ConfigurarMappeoCursos();
            ConfigurarMappeoGeneros();
            ConfigurarMappeoEstados();
            ConfigurarMappeoSangre();
            ConfigurarMappeoDoctores();
            ConfigurarMappeoHospitales();
            ConfigurarMappeoPacientes();


        }
        private void ConfigurarMappeoEstudiante()
        {
            CreateMap<CrearEstudiantesdto, Estudiante>()
                .ForMember(entidad => entidad.cursoEstudiantes
            , dto => dto.MapFrom(ce => ce.cursoId!.Select(id => new CursoEstudiante { cursoId = id })))
            .ForMember(x => x.Foto, opciones => opciones.Ignore())
            .ForMember(x => x.ActaNacimiento, opciones => opciones.Ignore());

            CreateMap<Estudiante, Estudiantesdto>()
                .ForMember(entidad => entidad.Cursos, dto =>
                dto.MapFrom(dto => dto.cursoEstudiantes));
            CreateMap<CursoEstudiante, Cursodto>()
                .ForMember(c => c.Id, ce => ce.MapFrom(ce => ce.cursoId))
                .ForMember(c => c.NombreCurso, ce => ce.MapFrom(ce => ce.curso.NombreCurso));
        }
        private void ConfigurarMappeoCursos()
        {
            CreateMap<CrearCursodto, Curso>();
            CreateMap<Curso, Cursodto>();
        }
        private void ConfigurarMappeoGeneros()
        {
            CreateMap<CrearGenerodto, Genero>();
            CreateMap<Genero, Generodto>();
        }
        private void ConfigurarMappeoEstados()
        {
            CreateMap<CrearEstadodto, Estado>();
            CreateMap<Estado, Estadodto>();
        }
        private void ConfigurarMappeoSangre()
        {
            CreateMap<CrearSangredto, Sangre>();
            CreateMap<Sangre, Sangredto>();
        }
        private void ConfigurarMappeoDoctores()
        {
            CreateMap<CrearDoctordto, Doctor>();
            CreateMap<Doctor, Doctordto>();
            CreateMap<Doctor, PacienteDoctordto>();
        }
        private void ConfigurarMappeoHospitales()
        {
            CreateMap<CrearHospitaldto, Hospital>();
            CreateMap<Hospital, Hospitaldto>();
            CreateMap<Hospital, PacienteHospitaldto>();
        }
        private void ConfigurarMappeoPacientes()
        {
            CreateMap<Crearpacientedto, Paciente>()
                .ForMember(x => x.PacienteGeneros, dto => dto.MapFrom(pg => pg.GeneroId!.Select(id => new PacienteGenero { GeneroId = id})))
                .ForMember(x => x.PacienteEstados, dto => dto.MapFrom(pe => pe.EstadoId!.Select(id => new PacienteEstado { EstadoId = id })))
                .ForMember(x => x.PacienteSangres, dto => dto.MapFrom(ps => ps.SangreId!.Select(id => new PacienteSangre { SangreId = id })))
                .ForMember(x => x.DoctorPacientes, dto => dto.MapFrom(dp => dp.Doctores!.Select(doctor => new DoctorPaciente { DoctorId = doctor.Id})))
                .ForMember(x => x.HospitalPacientes, dto => dto.MapFrom(hp => hp.Hospitales!.Select(hospital => new HospitalPaciente { HospitalId = hospital.Id })));
            CreateMap<Paciente, Pacientedto>();

            CreateMap<Paciente, PacienteDetalledto>()
                .ForMember(pg => pg.Generos, entidades => entidades.MapFrom(p=> p.PacienteGeneros))
                .ForMember(pe => pe.Estados, entidades => entidades.MapFrom(p => p.PacienteEstados))
                .ForMember(ps => ps.Sangres, entidades => entidades.MapFrom(p => p.PacienteSangres))
                .ForMember(dp => dp.Doctores, entidades => entidades.MapFrom(p => p.DoctorPacientes))
                .ForMember(hp => hp.Hospitales, entidades => entidades.MapFrom(p => p.HospitalPacientes));
            CreateMap<PacienteGenero, Generodto>()
                .ForMember(g => g.Id, pg => pg.MapFrom(pg => pg.GeneroId))
                .ForMember(g => g.Tipo, pg => pg.MapFrom(pg => pg.Genero.Tipo));
            CreateMap<PacienteEstado, Estadodto>()
                .ForMember(e => e.Id, pe => pe.MapFrom(pe => pe.EstadoId))
                .ForMember(e => e.Tipo, pe => pe.MapFrom(pe => pe.Estado.Tipo));
            CreateMap<PacienteSangre, Sangredto>()
                .ForMember(s => s.Id, ps => ps.MapFrom(ps => ps.SangreId))
                .ForMember(s => s.Tipo, ps => ps.MapFrom(ps => ps.Sangre.Tipo));
            CreateMap<DoctorPaciente, PacienteDoctordto>()
                .ForMember(dp => dp.Id, dto => dto.MapFrom(dto => dto.DoctorId))
                .ForMember(dp => dp.Nombre, dto => dto.MapFrom(dto => dto.Doctor.Nombre))
                .ForMember(dp => dp.Especialidad, dto => dto.MapFrom(dto => dto.Doctor.Especialidad));
                CreateMap<HospitalPaciente, PacienteHospitaldto>()
                .ForMember(hp => hp.Id, dto => dto.MapFrom(dto => dto.HospitalId))
                .ForMember(hp => hp.Nombre, dto => dto.MapFrom(dto => dto.Hospital.Nombre));

        }
    }
}
