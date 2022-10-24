namespace API.Models;

public class Invoice
{
    public int ID_Factura { get; set; }
    public float monto { get; set; }
    public List<string> productosConsumidos { get; set; }
    public float iva { get; set; }
    public List<string> servicios { get; set; }
    

}