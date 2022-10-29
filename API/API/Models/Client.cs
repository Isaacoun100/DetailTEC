namespace API.Models;

public class Client
{
    public string nombreCompleto { get; set; } = string.Empty;

    public List<int> telefonos { get; set; } = new List<int>();
    public string cedula { get; set; } = string.Empty;
    public string correo { get; set; }
    public string direccion { get; set; }
    public string usuario { get; set; } = string.Empty;
    public string contrasena { get; set; } = string.Empty;

    public int puntos { get; set; } = 0;

}