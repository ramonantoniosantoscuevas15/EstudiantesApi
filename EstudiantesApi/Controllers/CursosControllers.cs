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
        [OutputCache]
        public ActionResult Put(int id)
        {
            return new OkResult();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return new OkResult();
        }
    }
}
