using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EstudiantesApi.DTOs
{
    public class PacientesPutGetdto
    {
        public Pacientedto Paciente { get; set; } = null!;
        public List<Generodto>GeneroSeleccionado { get; set; } = new List<Generodto>();
        public List<Generodto>GeneroNoSeleccionado { get; set; } = new List<Generodto>();
        public List<Estadodto>EstadoSeleccionado { get; set;} = new List<Estadodto>();
        public List<Estadodto>EstadoNoSeleccionado { get; set;} = new List<Estadodto>();
        public List<Sangredto>SangreSeleccionado { get; set; } = new List<Sangredto>();
        public List<Sangredto>SangreNoSeleccionado { get; set; } = new List<Sangredto>();
        public List<PacienteDoctordto> Dotores { get; set; } = new List<PacienteDoctordto>();
        public List<PacienteHospitaldto> Hospitales { get; set; } = new List<PacienteHospitaldto>();
    }
}
