using EstudiantesApi.DTOs;

namespace EstudiantesApi.Utilidades
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, Paginaciondto paginacion)
        {
            return queryable
                .Skip((paginacion.pagina - 1) * paginacion.RecordsPorPagina)
                .Take(paginacion.RecordsPorPagina);

        }
    }
}
