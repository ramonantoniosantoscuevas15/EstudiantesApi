using EstudiantesApi.Utilidades;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EstudiantesApi.DTOs
{
    public class Crearpacientedto
    {
        [Required]
        [StringLength(30)]
        public required string Nombre { get; set; }
        public required DateTime FechaNacimiento { get; set; }
        public required int Cedula { get; set; }
        public required string Correo { get; set; }
        public required double Telefono { get; set; }
        [StringLength(150)]
        public required string Direccion { get; set; }
        [StringLength(50)]
        public string? Alegias { get; set; }
        [StringLength(150)]
        public string? NotasMedicas { get; set; }
        [StringLength(50)]
        public required string NombreContacto { get; set; }
        public required double TelefonoContacto { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder))]
        public List<int>? GeneroId {  get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder))]
        public List<int>? EstadoId { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder))]
        public List<int>? SangreId { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder))]
        public List<CrearDoctorPacientedto> Doctores { get; set; } = new List<CrearDoctorPacientedto>();
        [ModelBinder(BinderType = typeof(TypeBinder))]
        public List<CrearHospitalPacientedto> Hospitales { get; set; } = new List<CrearHospitalPacientedto>();


    }
}
