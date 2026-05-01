using AutoMapper;
using AutoMapper.QueryableExtensions;
using EstudiantesApi.DTOs;
using EstudiantesApi.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;

namespace EstudiantesApi.Controllers
{
    [Route("api/pacientes")]
    [ApiController]
    public class PacienteController: ControllerBase
    {
        private readonly IOutputCacheStore outputCacheStore;
        private readonly AplicationDBContext context;
        private readonly IMapper mapper;
        private const string cacheTag = "pacientes";

        public PacienteController(IOutputCacheStore outputCacheStore, AplicationDBContext context, IMapper mapper)
        {
            this.outputCacheStore = outputCacheStore;
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet("{id:int}", Name = "obtenerpacienteporid")]
        [OutputCache(Tags = [cacheTag])]
        public async Task<ActionResult<PacienteDetalledto>> Get(int id)
        {
            var paciente = await context.Pacientes
                .ProjectTo<PacienteDetalledto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);
            if(paciente == null)
            {
                return NotFound();
            }
            return paciente;
        }
        [HttpGet("PosGet")]
        public async Task<ActionResult<PacientesPostGetdto>> PosGet()
        {
            var generos = await context.Generos.ProjectTo<Generodto>(mapper.ConfigurationProvider).ToListAsync();
            var estados = await context.Estados.ProjectTo<Estadodto>(mapper.ConfigurationProvider).ToListAsync();
            var sangres = await context.Sangres.ProjectTo<Sangredto>(mapper.ConfigurationProvider).ToListAsync();
            
            return new PacientesPostGetdto() { Generos = generos, Estados = estados, Sangres = sangres };
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Crearpacientedto crearpaciente)
        {
            var paciente = mapper.Map<Paciente>(crearpaciente);
            context.Add(paciente);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheTag,default);
            var pacientedto = mapper.Map<Pacientedto>(paciente);
            return CreatedAtRoute("obtenerpacienteporid", new { id = paciente.Id }, pacientedto);
        }
        [HttpGet("PutGet/{id:int}")] 
        public async Task<ActionResult<PacientesPutGetdto>> PutGet(int id)
        {
            var paciente = await context.Pacientes
                .ProjectTo<PacienteDetalledto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);  
            if(paciente == null)
            {
                return NotFound();
            }
            var generosSeleccionadosIds = paciente!.Generos.Select(g=> g.Id).ToList();
            var generosNoSeleccionados = await context.Generos.Where(
                g=> !generosSeleccionadosIds.Contains(g.Id))
                .ProjectTo<Generodto>(mapper.ConfigurationProvider)
                .ToListAsync();
            var estadosSeleccionadosIds = paciente.Estados.Select(e => e.Id).ToList();
            var estadosNoSeleccionados = await context.Estados.Where(
                e => !estadosSeleccionadosIds.Contains(e.Id))
                .ProjectTo<Estadodto>(mapper.ConfigurationProvider)
                .ToListAsync();
            var sangresSeleccionadosIds = paciente.Sangres.Select(s => s.Id).ToList();
            var sangresNoSeleccionados = await context.Sangres.Where(
                s => !sangresSeleccionadosIds.Contains(s.Id))
                .ProjectTo<Sangredto>(mapper.ConfigurationProvider)
                .ToListAsync();
            var generosNoSeleccionadosdto = mapper.Map<List<Generodto>>(generosNoSeleccionados);
            var estadosNoSeleccionadosdto = mapper.Map<List<Estadodto>>(estadosNoSeleccionados);
            var sangresNoSeleccionadosdto = mapper.Map<List<Sangredto>>(sangresNoSeleccionados);
            var respuesta = new PacientesPutGetdto();
            respuesta.Paciente = paciente;
            respuesta.GeneroSeleccionado = paciente.Generos;
            respuesta.GeneroNoSeleccionado = generosNoSeleccionadosdto;
            respuesta.EstadoSeleccionado = paciente.Estados;
            respuesta.EstadoNoSeleccionado = estadosNoSeleccionadosdto;
            respuesta.SangreSeleccionado = paciente.Sangres;
            respuesta.SangreNoSeleccionado = sangresNoSeleccionadosdto;
            respuesta.Dotores = paciente.Doctores;
            respuesta.Hospitales = paciente.Hospitales;
            return respuesta;
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromForm] Crearpacientedto crearpacientedto)
        {
            var paciente = await context.Pacientes
                .Include(p => p.DoctorPacientes)
                .Include(p=> p.HospitalPacientes)
                .Include(p=> p.PacienteGeneros)
                .Include(p=> p.PacienteEstados)
                .Include(p=> p.PacienteSangres)
                .FirstOrDefaultAsync();
            if(paciente == null)
            {
                return NotFound();
            }
            paciente = mapper.Map(crearpacientedto, paciente);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheTag, default);
            return NoContent();

        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var registrosborrados = await context.Pacientes.Where(e => e.Id == id).ExecuteDeleteAsync();
            if (registrosborrados == 0)
            {
                return NotFound();
            }
            await outputCacheStore.EvictByTagAsync(cacheTag, default);
            return NoContent();
        }


    }
}
