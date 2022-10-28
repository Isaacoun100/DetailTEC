using API.Models;
using API.RequestFromDatabase;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/")]
[ApiController]
public class EmployeeController: ControllerBase
{
    
   
    
    [HttpPost("getEmployee")]
    public async Task<ActionResult<StatusJSON>> GetEmployee(ID cedula)
    {
        ManageEmployees manageEmployees = new ManageEmployees();
        Employee employee = manageEmployees.getEmployee(cedula.cedula.ToString());
        StatusJSON json;
        if (employee.cedula == 0)
        {
            json = new StatusJSON("error", null);
            return BadRequest(json);
        }

        json = new StatusJSON("ok", employee);
        return Ok(json);
    }

    [HttpGet("getAllEmployees")]
    public async Task<ActionResult<List<StatusJSON>>> getAllEmployees()
    {
        ManageEmployees manageEmployees = new ManageEmployees();
        List <Employee>  allEmployees= manageEmployees.GetAllEmployees();
        StatusJSON json;
        if (allEmployees.Count == 0)
        {
            json = new StatusJSON("Error",null);
            return BadRequest(json);

        }

        json = new StatusJSON("ok", allEmployees);
        return Ok(json);

    }
    

    [HttpPost("addEmployee")]
    public async Task<ActionResult<List<StatusJSON>>> addEmployee(Employee employee)
    {
        ManageEmployees employees = new ManageEmployees();
        var addedEmployee = employees.addEmployee(employee);
        StatusJSON json;
        if (!addedEmployee)
        {
            json = new StatusJSON("Error", "Employee not added");
            return BadRequest(json);
        }

        json = new StatusJSON("ok", employee);
        return Ok(json);
    }
    

    [HttpPut("updateEmployee")]
    public async Task<ActionResult<StatusJSON>> updateEmployee(Employee request)
    {

        ManageEmployees employees = new ManageEmployees();
        var updatedEmployee = employees.updateEmployee(request);
        StatusJSON json;
        if (!updatedEmployee)
        {
            json = new StatusJSON("Error",null);
            return BadRequest(json);
        }

        json = new StatusJSON("ok", request);
        return Ok(json);
    }

    [HttpDelete("deleteEmployee")]
    public async Task<ActionResult<StatusJSON>> deleteEmployee(ID employeeToDelete)
    {
        ManageEmployees employees = new ManageEmployees();
        var deletedEmployee = employees.deleteEmployee(employeeToDelete.cedula.ToString());
        StatusJSON json;
        if (!deletedEmployee)
        {
            json = new StatusJSON("error", null);
            return BadRequest(json);
        }

        json = new StatusJSON("ok", employeeToDelete);
        return Ok(json);

    }
    

}