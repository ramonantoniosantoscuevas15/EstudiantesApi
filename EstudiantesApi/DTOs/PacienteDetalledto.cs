namespace EstudiantesApi.DTOs
{
    public class PacienteDetalledto:Pacientedto
    {
        public List<Generodto> Generos { get; set; } = new List<Generodto>();
        public List<Estadodto> Estados { get; set;} = new List<Estadodto>();
        public List<Sangredto> Sangres { get; set; } = new List<Sangredto>();
        public List<PacienteDoctordto> Doctores { get; set; } = new List<PacienteDoctordto>();
        public List<PacienteHospitaldto> Hospitales { get; set; } = new List<PacienteHospitaldto>();
    }
}
