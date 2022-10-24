namespace API.Models;

public class StatusJSON
{
    public string status { get; set; } = string.Empty;
    public Object result { get; set; }
    
    
    public StatusJSON(string status, Object result)
    {
        this.status = status;
        if (result == null)
        {
            this.result = "{}";
        }
        else
        {
            this.result = result;
        }

        
    }
    
}