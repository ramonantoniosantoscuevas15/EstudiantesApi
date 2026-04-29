using AutoMapper;
using AutoMapper.QueryableExtensions;
using EstudiantesApi.DTOs;
using EstudiantesApi.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;

namespace EstudiantesApi.Controllers
{
    [Route("api/doctores")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IOutputCacheStore outputCacheStore;
        private readonly AplicationDBContext context;
        private readonly IMapper mapper;
        private const string cacheTag = "doctores";

        public DoctorController(IOutputCacheStore outputCacheStore, AplicationDBContext context, IMapper mapper)
        {
            this.outputCacheStore = outputCacheStore;
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet("{id:int}", Name = "obtenerdoctorporid")]
        [OutputCache(Tags = [cacheTag])]
        public async Task<ActionResult<Doctordto>> Get(int id)
        {
            var doctor = await context.Dotores
                .ProjectTo<Doctordto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(d => d.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }
            return doctor;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CrearDoctordto creardoctor)
        {
            var doctor = mapper.Map<Doctor>(creardoctor);
            context.Add(doctor);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheTag, default);
            return CreatedAtRoute("obtenerdoctorporid", new { id = doctor.Id }, doctor);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CrearDoctordto creardoctor)
        {
            var doctorexistente = await context.Dotores.AnyAsync(d => d.Id == id);
            if (!doctorexistente)
            {
                return NotFound();
            }
            var doctor = mapper.Map<Doctor>(creardoctor);
            doctor.Id = id;
            context.Update(doctor);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheTag, default);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var registrosBorrados = await context.Cursos
                .Where(c => c.Id == id)
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
