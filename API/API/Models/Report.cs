namespace API.Models;

public class Report
{
    public string tipoPago { get; set; } = string.Empty;
    public string nombreCompleto { get; set; } = string.Empty;
    public float montoTotal { get; set; }
    public List<WashQuantity> cantidadLavados { get; set; }

}