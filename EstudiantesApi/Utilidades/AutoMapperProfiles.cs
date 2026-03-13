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

        }
        private void ConfigurarMappeoEstudiante()
        {
            CreateMap<CrearEstudiantesdto, Estudiante>()
            //    .ForMember(entidad => entidad.cursoEstudiantes
            //, dto => dto.MapFrom(ce => ce.cursoId!.Select(id => new CursoEstudiante { cursoId = id })));
            .ForMember(x => x.Foto, opciones => opciones.Ignore())
            .ForMember(x => x.ActaNacimiento, opciones => opciones.Ignore());
            CreateMap<Estudiante, Estudiantesdto>();
        }
    }
}
