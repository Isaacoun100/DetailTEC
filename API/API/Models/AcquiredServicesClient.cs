namespace API.Models;

public class AcquiredServicesClient
{
    public string client { get; set; } = string.Empty;
    public List<Wash> lavadosRealizados { get; set; }
    
}