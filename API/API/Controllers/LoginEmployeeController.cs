using API.Models;
using API.RequestFromDatabase;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[Route("api/")]
[ApiController]
public class LoginEmployeeController : ControllerBase
{
    
    [HttpPost("auth")]
    public async Task<ActionResult<StatusJSON>> Authenticate(CredentialsEmployee credentials)
    {
        Console.WriteLine(credentials.cedula+credentials.contrasena);
        ManageEmployees employees = new ManageEmployees();
        var existingEmployee = employees.loginEmployee(credentials.cedula, credentials.contrasena);
        StatusJSON json;
        if (existingEmployee.cedula == 0)
        {
            json = new StatusJSON("error", null);
            return BadRequest(json);
        }

        ID employeeID = new ID();
        employeeID.cedula = existingEmployee.cedula;
        
        json = new StatusJSON("ok", employeeID);
        return Ok(json);

    }


}