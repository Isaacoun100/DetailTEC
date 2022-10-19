namespace API.Models;

public class Client
{
    public string nombreCompleto { get; set; } = string.Empty;
    public List<int> telefonos { get; set; }
    public int cedula { get; set; }
    public string correo { get; set; }
    public List<string> direccion { get; set; }
    public string usuario { get; set; } = string.Empty;
    public string contrasena { get; set; } = string.Empty;
    
}