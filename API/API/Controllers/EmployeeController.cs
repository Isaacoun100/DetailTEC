using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/")]
[ApiController]
public class EmployeeController: ControllerBase
{
    
    private static List<Employee> employees = new List<Employee>();
    
    [HttpPost("getEmployee")]
    public async Task<ActionResult<Employee>> GetEmployee(ID cedula)
    {
        //se busca el employee con el parametro cedula, si existe se devuelve la información de este 
        //usando el modelo de employee 
        Console.WriteLine(cedula.cedula);

        var employee = employees.Find(h => h.cedula == cedula.cedula);
        if (employee == null)
        {
            return BadRequest("Employee not found");
            
        }

        return Ok(employee);
    }

    [HttpPost("addEmployee")]
    public async Task<ActionResult<List<Employee>>> addEmployee(Employee employee)
    {
        //añadir a un employee nuevo a la base
        employees.Add(employee);
        return Ok(employees);
    }
    

    [HttpPut("updateEmployee")]
    public async Task<ActionResult<Employee>> updateEmployee(Employee request)
    {
        //encontrar el empleado con la base y se reemplaza con el resto de atributos de employee
        var employee = employees.Find(h => h.cedula == request.cedula);
        if (employee == null)
        {
            return BadRequest("Employee not found");
        }

        employee.nombre = request.nombre;
        employee.apellidos = request.apellidos;
        employee.fechaIngreso = request.fechaIngreso;
        employee.fechaNacimiento = request.fechaNacimiento;
        employee.edad = request.edad;
        employee.contrasena = request.contrasena;
        employee.rol = request.rol;
        employee.tipoPago = request.tipoPago;

        return Ok(employees);

    }

    [HttpDelete("deleteEmployee")]
    public async Task<ActionResult<Employee>> deleteEmployee(ID employeeToDelete)
    {
        
        //encontrar el empleado con la base y se reemplaza con el resto de atributos de employee
        var deleteEmployee = employees.Find(h => h.cedula == employeeToDelete.cedula);
        if (deleteEmployee == null)
        {
            BadRequest("Employee not found");
        }

        employees.Remove(deleteEmployee);
        return Ok(employees);
    }
    

}