namespace EstudiantesApi.DTOs
{
    public class EstudiantesFiltrodto
    {
        public int Pagina { get; set; } 
        public int RecordsPorPagina { get; set; }
        internal Paginaciondto Paginacion { get {
                return new Paginaciondto()
                {
                    pagina = Pagina,
                    RecordsPorPagina = RecordsPorPagina
                };
        } }
        public string? Nombre { get; set; }
        public int CursoId { get; set; }
    }
}
