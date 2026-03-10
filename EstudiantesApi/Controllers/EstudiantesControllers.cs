using Microsoft.AspNetCore.Mvc;

namespace EstudiantesApi.Controllers
{
    [Route("api/estudiantes")]
    [ApiController]
    public class EstudiantesControllers
    {
        [HttpGet]
        public ActionResult Get()
        {
            return new OkResult();
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
