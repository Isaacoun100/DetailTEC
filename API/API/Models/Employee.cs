namespace API.Models;

public class Employee
{
    public string nombre { get; set; } = string.Empty;
    public string apellidos { get; set; } = string.Empty;
    public int cedula { get; set; }
    public string fechaIngreso { get; set; } = string.Empty;
    public string fechaNacimiento { get; set; } = string.Empty;
    public int edad { get; set; }
    public string contrasena { get; set; } = string.Empty;
    public string rol { get; set; } = string.Empty;
    public string tipoPago { get; set; } = string.Empty;


}