using AutoMapper;
using AutoMapper.QueryableExtensions;
using EstudiantesApi.DTOs;
using EstudiantesApi.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;

namespace EstudiantesApi.Controllers
{
    [Route("api/estados")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly IOutputCacheStore outputCacheStore;
        private readonly AplicationDBContext context;
        private readonly IMapper mapper;
        private const string cacheTag = "estados";

        public EstadoController(IOutputCacheStore outputCacheStore, AplicationDBContext context, IMapper mapper)
        {
            this.outputCacheStore = outputCacheStore;
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet("{id:int}", Name = "obtenerestadoporid")]
        [OutputCache(Tags = [cacheTag])]
        public async Task<ActionResult<Estadodto>> Get(int id)
        {
            var estado = await context.Generos.ProjectTo<Estadodto>
                (mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id);
            if (estado == null)
            {
                return NotFound();
            }
            return estado;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CrearEstadodto crearEstado)
        {
            var estado = mapper.Map<Estado>(crearEstado);
            context.Add(estado);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheTag, default);
            return CreatedAtRoute("obtenerestadoporid", new { id = estado.Id }, estado);
        }
    }
}
