namespace API.Models;

public class Provider
{
    public string nombre { get; set; } = string.Empty;
    public int cedulaJuridica { get; set; }
    public string direccion { get; set; } = string.Empty;
    public string correo { get; set; } = string.Empty;
    public string contacto { get; set; } = string.Empty;
    
    //Se debe añadir un listado de los productos que provee ese proveedor especifico algo como
    public List<String> productList { get; set; } = new List<string>();

}