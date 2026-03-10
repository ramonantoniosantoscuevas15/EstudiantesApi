using EstudiantesApi.Entidades;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace EstudiantesApi.Controllers
{
    [Route("api/cursos")]
    [ApiController]
    
    public class CursosControllers:ControllerBase
    {
        [HttpGet]
        [OutputCache]
        public List<Curso> Get()
        {
            return new List<Curso>
            {
                new Curso { Id = 1, Nombre = "Matemáticas" },
                new Curso { Id = 2, Nombre = "Historia" },
                new Curso { Id = 3, Nombre = "Ciencias" }
            };
        }

        [HttpPost]
        public ActionResult Post([FromBody] Curso curso)
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
