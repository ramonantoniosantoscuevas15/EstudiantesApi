namespace EstudiantesApi.DTOs
{
    public class PacientesPostGetdto
    {
        public List<Generodto> Generos { get; set; } = new List<Generodto>();
        public List<Estadodto> Estados { get; set;} = new List<Estadodto>();
        public List<Sangredto> Sangres { get; set; } = new List<Sangredto>();

    }
}
