using AutoMapper;
using AutoMapper.QueryableExtensions;
using EstudiantesApi.DTOs;
using EstudiantesApi.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;

namespace EstudiantesApi.Controllers
{
    [Route("api/generos")]
    [ApiController]
    public class GenerosControllers : ControllerBase
    {
        private readonly IOutputCacheStore outputCacheStore;
        private readonly AplicationDBContext context;
        private readonly IMapper mapper;
        private const string cacheTag = "generos";

        public GenerosControllers(IOutputCacheStore outputCacheStore, AplicationDBContext context, IMapper mapper)
        {
            this.outputCacheStore = outputCacheStore;
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet("{id:int}", Name = "obtenergeneroporid")]
        [OutputCache(Tags = [cacheTag])]
        public async Task<ActionResult<Generodto>> Get(int id)
        {
            var genero = await context.Generos.ProjectTo<Generodto>
                (mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id);
            if (genero == null)
            {
                return NotFound();
            }
            return genero;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CrearGenerodto crearGenero)
        {
            var genero = mapper.Map<Genero>(crearGenero);
            context.Add(genero);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheTag, default);
            return CreatedAtRoute("obtenergeneroporid", new { id = genero.Id }, genero);

        }
    }
}
