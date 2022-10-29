namespace API.Models;

public class Branch
{
    public string nombre { get; set; } = string.Empty;
    public string fechaInicioGerente { get; set; } = string.Empty;
    
    //Fecha apertura was added, should be implemented in the API
    public string fechaApertura { get; set; } = string.Empty;
    
    //Ubicacion should be splitted into 3 (provincia, canton, distrito) 
    public List<string> ubicacion { get; set; }
    public int gerente { get; set; }
    public string telefono { get; set; } = string.Empty;
    
    // A list of employees that work in that branch may be useful, [Low priority]
    
}