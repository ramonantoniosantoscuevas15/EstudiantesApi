using EstudiantesApi.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace EstudiantesApi.Controllers
{
    [Route("api/estudiantes")]
    [ApiController]
    
    public class EstudiantesControllers:ControllerBase
    {
        [HttpGet]
        [OutputCache]
        public ActionResult Get()
        {
            return new OkResult();
        }
        [HttpPost]
        public ActionResult Post([FromBody] Estudiante estudiante)
        {
            return new OkResult();
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
