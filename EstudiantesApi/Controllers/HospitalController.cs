using AutoMapper;
using AutoMapper.QueryableExtensions;
using EstudiantesApi.DTOs;
using EstudiantesApi.Entidades;
using EstudiantesApi.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;

namespace EstudiantesApi.Controllers
{
    [Route("api/hospitales")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IOutputCacheStore outputCacheStore;
        private readonly AplicationDBContext context;
        private readonly IMapper mapper;
        private const string cacheTag = "hospital";

        public HospitalController(IOutputCacheStore outputCacheStore, AplicationDBContext context, IMapper mapper)
        {
            this.outputCacheStore = outputCacheStore;
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet("{id:int}", Name = "obtenerhospitalporid")]
        [OutputCache(Tags = [cacheTag])]
        public async Task<ActionResult<Hospitaldto>> Get(int id)
        {
            var hopital = await context.Hospitales
                .ProjectTo<Hospitaldto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (hopital == null)
            {
                return NotFound();
            }
            return hopital;

        }
        [HttpGet]//api/hospitales
        [OutputCache(Tags = [cacheTag])]
        public async Task<List<Hospitaldto>> Get([FromQuery] Paginaciondto paginacion)
        {
            var queryable = context.Hospitales;
            await HttpContext.InsertarParametrosPaginacionEncabecera(queryable);
            return await queryable
                .OrderBy(h => h.Nombre)
                .Paginar(paginacion)
                .ProjectTo<Hospitaldto>(mapper.ConfigurationProvider)
                .ToListAsync();

        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CrearHospitaldto crearhospital)
        {
            var hospital = mapper.Map<Hospital>(crearhospital);
            context.Add(hospital);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheTag, default);

            return CreatedAtRoute("obtenerhospitalporid", new { id = hospital.Id }, hospital);
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, [FromBody] CrearHospitaldto crearhospital)
        {
            var hospialexistente = await context.Hospitales.AnyAsync(h => h.Id == id);
            if (!hospialexistente)
            {
                return NotFound();
            }
            var hospital = mapper.Map<Hospital>(crearhospital);
            hospital.Id = id;
            context.Update(hospital);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheTag, default);
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var registrosBorrados = await context.Hospitales
                .Where(h => h.Id == id)
                .ExecuteDeleteAsync();
            if (registrosBorrados == 0)
            {
                return NotFound();

            }
            await outputCacheStore.EvictByTagAsync(cacheTag, default);
            return NoContent();
        }
    }
}
