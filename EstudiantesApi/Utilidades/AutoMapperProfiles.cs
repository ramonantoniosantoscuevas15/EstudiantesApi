using AutoMapper;
using EstudiantesApi.DTOs;
using EstudiantesApi.Entidades;

namespace EstudiantesApi.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {

        }
        private void ConfigurarMappeoEstudiante()
        {
            CreateMap<CrearEstudiantesdto, Estudiante>().ForMember(entidad => entidad.cursoEstudiantes
            , dto => dto.MapFrom(ce => ce.cursoId!.Select(id => new CursoEstudiante { cursoId = id })));
        }
    }
}
