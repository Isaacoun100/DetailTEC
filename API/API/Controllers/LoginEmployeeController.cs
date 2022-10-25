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
        ManageEmployees employees = new ManageEmployees();
        var existingEmployee = employees.loginEmployee(credentials.cedula, credentials.contrasena);
        StatusJSON json;
        if (existingEmployee.cedula == 0)
        {
            json = new StatusJSON("Error", null);
            return BadRequest(json);
        }

        ID employeeID = new ID();
        employeeID.cedula = existingEmployee.cedula;
        
        json = new StatusJSON("Ok", employeeID);
        return Ok(json);

    }


}