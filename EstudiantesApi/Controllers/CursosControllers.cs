using EstudiantesApi.Entidades;

using Microsoft.AspNetCore.Mvc;

namespace EstudiantesApi.Controllers
{
    [Route("api/cursos")]
    [ApiController]
    public class CursosControllers
    {
        [HttpGet]
        public List<Cursos> Get()
        {
            return new List<Cursos>
            {
                new Cursos { Id = 1, Nombre = "Matemáticas" },
                new Cursos { Id = 2, Nombre = "Historia" },
                new Cursos { Id = 3, Nombre = "Ciencias" }
            };
        }
    }
}
