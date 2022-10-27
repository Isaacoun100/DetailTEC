namespace API.Models;

public class Invoice
{
    public int ID_Factura { get; set; }
    
    // Preferiblemente que sea un int, pero no hay problema con que sea un float si es necesario
    public float monto { get; set; }
    public List<string> productosConsumidos { get; set; }
    // Dado que el iva en la BD se almacena como int, no es necesario el uso de float, sería preferible cambiarlo
    public float iva { get; set; }
    
    // El servicio no es un List, cada factura tiene un lavado unicamente, se ocupa pasar a string
    public List<string> servicios { get; set; }
    

}