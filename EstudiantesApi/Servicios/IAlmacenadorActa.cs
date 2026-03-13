namespace EstudiantesApi.Servicios
{
    public interface IAlmacenadorActa
    {
        Task<string> AlmacenarActa(string contenedoracta, IFormFile archivo);
        Task Borrar(string? rutaacta, string contenedoracta);
        async Task<string> Editar(string? rutaacta, string contenedoracta, IFormFile archivo)
        {
            await Borrar(rutaacta, contenedoracta);
            return await AlmacenarActa(contenedoracta, archivo);
        }
    }
}
