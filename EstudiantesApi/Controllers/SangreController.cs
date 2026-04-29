using AutoMapper;
using AutoMapper.QueryableExtensions;
using EstudiantesApi.DTOs;
using EstudiantesApi.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;

namespace EstudiantesApi.Controllers
{
    [Route("api/sangre")]
    [ApiController]
    public class SangreController : ControllerBase
    {
        private readonly IOutputCacheStore outputCacheStore;
        private readonly AplicationDBContext context;
        private readonly IMapper mapper;
        private const string cacheTag = "sangre";

        public SangreController(IOutputCacheStore outputCacheStore, AplicationDBContext context, IMapper mapper)
        {
            this.outputCacheStore = outputCacheStore;
            this.context = context;
            this.mapper = mapper;

        }
        [HttpGet("{id:int}", Name = "obtenersangreporid")]
        [OutputCache(Tags = [cacheTag])]
        public async Task<ActionResult<Sangredto>> Get(int id)
        {
            var sangre = await context.Sangres.ProjectTo<Sangredto>
                (mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id);
            if (sangre == null)
            {
                return NotFound();
            }
            return sangre;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CrearSangredto crearSangre)
        {
            var sangre = mapper.Map<Sangre>(crearSangre);
            context.Add(sangre);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheTag, default);
            return CreatedAtRoute("obtenersangreporid", new { id = sangre.Id }, sangre);
        }
    }
}
