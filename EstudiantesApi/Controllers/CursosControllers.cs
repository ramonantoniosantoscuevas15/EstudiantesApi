using AutoMapper;
using AutoMapper.QueryableExtensions;
using EstudiantesApi.DTOs;
using EstudiantesApi.Entidades;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using EstudiantesApi.Utilidades;
namespace EstudiantesApi.Controllers
{
    [Route("api/cursos")]
    [ApiController]
    
    public class CursosControllers:ControllerBase
    {
        private readonly IOutputCacheStore outputCacheStore;
        private readonly AplicationDBContext context;
        private readonly IMapper mapper;
        private const string cacheTag = "cursos";

        public CursosControllers(IOutputCacheStore outputCacheStore,AplicationDBContext context,IMapper mapper)
        {
            this.outputCacheStore = outputCacheStore;
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet("{id:int}", Name = "obtenercursoporid")]
        [OutputCache(Tags = [cacheTag])]
        public async Task<ActionResult<Cursodto>>  Get(int id)
        {
            var curso = await context.Cursos
                .ProjectTo<Cursodto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(c => c.Id == id);

            if(curso == null)
            {
                return NotFound();
            }   
            return curso;

        }
        [HttpGet]//api/cursos
        [OutputCache(Tags = [cacheTag])]
        public async Task<List<Cursodto>> Get([FromQuery] Paginaciondto paginacion)
        {
            var queryable = context.Cursos;
            await HttpContext.InsertarParametrosPaginacionEncabecera(queryable);
            return await queryable
                .OrderBy(c => c.NombreCurso)
                .Paginar(paginacion)
                .ProjectTo<Cursodto>(mapper.ConfigurationProvider)
                .ToListAsync();

        }

        [HttpPost]
        public async Task <IActionResult> Post([FromBody] CrearCursodto crearCurso)
        {
            var curso = mapper.Map<Curso>(crearCurso);
            context.Add(curso);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheTag,default);

            return CreatedAtRoute("obtenercursoporid", new { id = curso.Id }, curso);
        }

        [HttpPut("{id}")]
        
        public async Task <IActionResult>  Put(int id, [FromBody] CrearCursodto crearCurso)
        {
            var cursosexistente = await context.Cursos.AnyAsync(c => c.Id == id);
            if (!cursosexistente)
            {
                return NotFound();
            }
            var curso = mapper.Map<Curso>(crearCurso);
            curso.Id = id;
            context.Update(curso);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheTag,default);
            return NoContent();
        }
        [HttpGet("todos")]
        [OutputCache(Tags = [cacheTag])]
        public async Task<List<Cursodto>> Get()
        {
            return await context.Cursos
                .OrderBy(c => c.NombreCurso)
                .ProjectTo<Cursodto>(mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var registrosBorrados = await context.Cursos
                .Where(c=> c.Id == id)
                .ExecuteDeleteAsync();
            if (registrosBorrados ==0)
            {
                return NotFound();

            }
            await outputCacheStore.EvictByTagAsync(cacheTag,default);
            return NoContent();
        }
    }
}
