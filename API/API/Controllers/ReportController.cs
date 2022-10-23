using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[Route("api/")]
[ApiController]
public class ReportController : ControllerBase
{
    private static List<Report> reports = new List<Report>();
    private static List<AcquiredServicesClient> acquiredServices = new List<AcquiredServicesClient>();

    [HttpPost("getReport")]
    public async Task<ActionResult<Report>> getReport(string name)
    {
        var report = reports.Find(h => h.nombreCompleto == name);
        if (report == null)
        {
            return BadRequest("Report not found");
        }

        return Ok(report);
    }

    [HttpPost("acquiredService")]
    public async Task<ActionResult<Report>> acquiredService(string clientName)
    {
        var acquiredService = acquiredServices.Find(h => h.client == clientName);
        if (acquiredService == null)
        {
            return BadRequest("Acquired service not found");
        }

        return Ok(acquiredService);
    }
    
    
    







}