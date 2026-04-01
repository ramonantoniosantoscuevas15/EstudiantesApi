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
            CreateMap<CrearCursodto,Curso>();
             CreateMap<Curso, Cursodto>();  
        }
    }
}
