namespace API.Models;

public class Product
{
    public string nombre { get; set; } = string.Empty;
    public string marca { get; set; } = string.Empty;
    public int costo { get; set; }
    public List<string> proveedores { get; set; }
    
    
}