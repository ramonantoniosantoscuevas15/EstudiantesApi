using EstudiantesApi.Entidades;

using Microsoft.AspNetCore.Mvc;

namespace EstudiantesApi.Controllers
{
    [Route("api/cursos")]
    [ApiController]
    public class CursosControllers
    {
        [HttpGet]
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
        public ActionResult Post()
        {
            return new OkResult();
        }

        [HttpPut("{id}")]
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
