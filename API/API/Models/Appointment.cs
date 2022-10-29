namespace API.Models;

public class Appointment
{
    public int cliente { get; set; }
    public string placaVehiculo { get; set; } = string.Empty;
    public string sucursal { get; set; } = string.Empty;
    
    // Must be an int, and if possible renamed to idLavado
    public string tipoLavado { get; set; } = string.Empty;
    
    // Not in the database
    public string responsable { get; set; } = string.Empty;
    
    // Must be int
    public string factura { get; set; } = string.Empty;
    public int numeroCita { get; set; }
    
}