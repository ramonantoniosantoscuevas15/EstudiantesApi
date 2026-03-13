using AutoMapper;
using AutoMapper.QueryableExtensions;
using EstudiantesApi.DTOs;
using EstudiantesApi.Entidades;
using EstudiantesApi.Servicios;
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

            return new OkResult();
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
            return CreatedAtRoute("obtenerporid", new {id = estudiante.Id},estudiante);

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
