using AutoMapper;
using AutoMapper.QueryableExtensions;
using EstudiantesApi.DTOs;
using EstudiantesApi.Entidades;
using EstudiantesApi.Servicios;
using EstudiantesApi.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;

namespace EstudiantesApi.Controllers
{
    [Route("api/estudiantes")]
    [ApiController]
    
    public class EstudiantesControllers:ControllerBase
    {
        private readonly IOutputCacheStore outputCacheStore;
        private readonly AplicationDBContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorFotos almacenadorFotos;
        private readonly IAlmacenadorActa almacenadorActa;
        private readonly string contenedor = "estudiantes";
        private readonly string contenedoracta = "estudiantes";
        private const string cachetag = "estudiantes";
        public EstudiantesControllers(IOutputCacheStore outputCacheStore, 
            AplicationDBContext context, IMapper mapper, IAlmacenadorFotos almacenadorFotos,IAlmacenadorActa almacenadorActa)
        {
            this.outputCacheStore = outputCacheStore;
            this.context = context;
            this.mapper = mapper;
            this.almacenadorFotos = almacenadorFotos;
            this.almacenadorActa = almacenadorActa;
        }
        [HttpGet("{id:int}", Name = "obtenerporid")]
        [OutputCache(Tags = [cachetag])]
        public async Task<ActionResult<Estudiantesdto>>  Get(int id)
        {
            var estudiante = await context.Estudiantes
                .ProjectTo<Estudiantesdto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(e => e.Id == id);
            if(estudiante == null)
            {
                return NotFound();
            }

            return estudiante;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CrearEstudiantesdto crearEstudiantesdto)
        {
            var estudiante = mapper.Map<Estudiante>(crearEstudiantesdto);
            if(crearEstudiantesdto.Foto is not null)
            {
                var url = await almacenadorFotos.Almacenar(contenedor,crearEstudiantesdto.Foto);
                estudiante.Foto = url;
            }
            if(crearEstudiantesdto.ActaNacimiento is not null)
            {
                var url = await almacenadorActa.AlmacenarActa(contenedoracta,crearEstudiantesdto.ActaNacimiento);
                estudiante.ActaNacimiento = url;
            }
            context.Add(estudiante);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cachetag,default);
            var estudianteDto = mapper.Map<Estudiantesdto>(estudiante);
            return CreatedAtRoute("obtenerporid", new {id = estudiante.Id},estudianteDto);

        }
        
        [HttpPut("{id:int}")]
        
        public async Task<IActionResult>Put(int id,[FromForm] CrearEstudiantesdto estudiantesdto)
        {
            var estudiante = await context.Estudiantes
                .Include(e=> e.cursoEstudiantes)
                .FirstOrDefaultAsync(e => e.Id == id);
            if(estudiante == null)
            {
                return NotFound();
            }
            estudiante = mapper.Map(estudiantesdto,estudiante);
            if(estudiantesdto.Foto is not null)
            {
                estudiante.Foto = await almacenadorFotos.Editar(estudiante.Foto, contenedor, estudiantesdto.Foto);
            }
            if(estudiantesdto.ActaNacimiento is not null)
            {
                estudiante.ActaNacimiento = await almacenadorActa.Editar(estudiante.ActaNacimiento, contenedoracta, estudiantesdto.ActaNacimiento);
            }

            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cachetag,default);
            return NoContent();
        }
        [HttpGet("PostCurso")]
        public async Task<ActionResult<CursoEstudiantedto>> PostCurso()
        {
            var cursos = await context.Cursos
                .ProjectTo<Cursodto>(mapper.ConfigurationProvider)
                .ToListAsync();
            return new CursoEstudiantedto { Cursos = cursos };

        }
        [HttpGet("Putget/{id:int}")]
        public async Task<ActionResult<EstudiantePutgetdto>> Putget (int id)
        {
            var estudiante = await context.Estudiantes
                .ProjectTo<Estudiantesdto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(e => e.Id == id);
            if(estudiante == null)
            {
                NotFound();
            }
            var cursosSeleccionadosIds = estudiante!.Cursos.Select(c => c.Id).ToList();
            var cursosNoSeleccionados = await context.Cursos.Where
                (cs => !cursosSeleccionadosIds.Contains(cs.Id))
                .ProjectTo<Cursodto>(mapper.ConfigurationProvider)
                .ToListAsync();
            var respuesta = new EstudiantePutgetdto();
            respuesta.Estudiante = estudiante;
            respuesta.cursoSeleccionado = estudiante.Cursos;
            respuesta.cursoNoSeleccionado = cursosNoSeleccionados;
            return respuesta;
        }
        [HttpDelete("{id:int}")]
        public async Task <IActionResult> Delete(int id)
        {
            var registrosborrados = await context.Estudiantes.Where(e => e.Id == id).ExecuteDeleteAsync();
            if(registrosborrados == 0)
            {
                return NotFound();
            }
            await outputCacheStore.EvictByTagAsync(cachetag,default);
            return NoContent();
        }
        [HttpGet] //api/estudiantes/lista
        [OutputCache(Tags = [cachetag])]
        public async Task<List<Estudiantesdto>> Get([FromQuery] Paginaciondto paginacion)
        {
            var queryable = context.Estudiantes;
            await HttpContext.InsertarParametrosPaginacionEncabecera(queryable);
            return await queryable
                .Where(e =>e.cursoEstudiantes.Select(ce=> ce.estudianteId).Contains(e.Id))
                .OrderBy(e => e.Nombre)
                .Paginar(paginacion)
                .ProjectTo<Estudiantesdto>(mapper.ConfigurationProvider).ToListAsync();
        }
        [HttpGet("todos")]
        [OutputCache(Tags = [cachetag])]
        public async Task<List<Estudiantesdto>> Get()
        {
            return await context.Estudiantes
                .OrderBy(e => e.Nombre)
                .ProjectTo<Estudiantesdto>(mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpGet("buscar")]
        [OutputCache(Tags = [cachetag])]
        public async Task<List<Estudiantesdto>> Buscar([FromQuery] EstudiantesFiltrodto estudiantesFiltrodto)
        {
            var estudiantesQueryable = context.Estudiantes.AsQueryable();
            if(!string.IsNullOrEmpty(estudiantesFiltrodto.Nombre))
            {
                estudiantesQueryable = estudiantesQueryable.Where(e => e.Nombre.Contains(estudiantesFiltrodto.Nombre));
            }
            if(estudiantesFiltrodto.CursoId != 0)
            {
                estudiantesQueryable = estudiantesQueryable.Where(e =>e.cursoEstudiantes.Select(ce => ce.cursoId).Contains(estudiantesFiltrodto.CursoId));

            }
            await HttpContext.InsertarParametrosPaginacionEncabecera(estudiantesQueryable);
            var estudiante = await estudiantesQueryable.Paginar(estudiantesFiltrodto.Paginacion)
                .ProjectTo<Estudiantesdto>(mapper.ConfigurationProvider).ToListAsync();
            return estudiante;
        }

    }

}
