
namespace EstudiantesApi.Servicios
{
    public  class Almacenadoractaslocal : IAlmacenadorActa
    {
        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor httpContextAccessor;

        public Almacenadoractaslocal(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            this.env = env;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> AlmacenarActa(string contenedoracta, IFormFile archivo)
        {
            var extesion = Path.GetExtension(archivo.FileName);
            var nombreArchivo = $"{Guid.NewGuid()}{extesion}";
            string folder = Path.Combine(env.WebRootPath, contenedoracta);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string rutaacta = Path.Combine(folder, nombreArchivo);
            using (var ms = new MemoryStream())
            {
                await archivo.CopyToAsync(ms);
                var contenidoacta = ms.ToArray();
                await File.WriteAllBytesAsync(rutaacta, contenidoacta);

            }
            var request = httpContextAccessor.HttpContext!.Request!;
            var url = $"{request.Scheme}//{request.Host}";
            var urlArchivo = Path.Combine(url, contenedoracta, nombreArchivo).Replace("\\", "/");
            return urlArchivo;
        }

        public Task Borrar(string? rutaacta, string contenedoracta)
        {
            if (string.IsNullOrWhiteSpace(rutaacta))
            {
                return Task.CompletedTask;
            }

            var nombreArchivo = Path.GetFileName(rutaacta);
            var directorioArchivo = Path.Combine(env.WebRootPath, contenedoracta, nombreArchivo);

            if (File.Exists(directorioArchivo))
            {
                File.Delete(directorioArchivo);
            }
            return Task.CompletedTask;
        }
    }
}
