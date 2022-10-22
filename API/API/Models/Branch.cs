namespace API.Models;

public class Branch
{
    public string nombre { get; set; } = string.Empty;
    public string fechaInicioGerente { get; set; } = string.Empty;
    public string ubicacion { get; set; } = string.Empty;
    public int gerente { get; set; }
    public string telefono { get; set; } = string.Empty;
    
}