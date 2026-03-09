namespace EstudiantesApi.Entidades
{
    public class Estudiante
    {
        int Id { get; set; }
        string Nombre { get; set; } = null!;
        string Apellido { get; set; } = null!;
        string? NombrePadre { get; set; }
        string? NombreMadre { get; set; }
        string? NombreTutor { get; set; }
        double Telefono { get; set; } 
        string Direccion { get; set; } = null!;
        string? Foto { get; set; } 
        string? ActaNacimiento { get; set; }



    }
}
