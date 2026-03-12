using AutoMapper;
using EstudiantesApi.DTOs;
using EstudiantesApi.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace EstudiantesApi.Controllers
{
    [Route("api/estudiantes")]
    [ApiController]
    
    public class EstudiantesControllers:ControllerBase
    {
        private readonly IOutputCacheStore outputCacheStore;
        private readonly AplicationDBContext context;
        private readonly IMapper mapper;
        private const string cachetag = "estudiantes";
        public EstudiantesControllers(IOutputCacheStore outputCacheStore, AplicationDBContext context, IMapper mapper)
        {
            this.outputCacheStore = outputCacheStore;
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        [OutputCache]
        public ActionResult Get()
        {
            return new OkResult();
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CrearEstudiantesdto crearEstudiantesdto)
        {
            var estudiante = mapper.Map<Estudiante>(crearEstudiantesdto);

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
