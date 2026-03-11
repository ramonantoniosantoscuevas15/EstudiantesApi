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
                new Curso { Id = 1, NombreCurso = "Matemáticas" },
                new Curso { Id = 2, NombreCurso = "Historia" },
                new Curso { Id = 3, NombreCurso = "Ciencias" }
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
