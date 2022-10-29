using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/")]
[ApiController]
public class CarWashTypeController: ControllerBase
{

    private static List<CarWashType> carWashTypes = new List<CarWashType>();
    
    [HttpPost("getCarWashType")]
    public async Task<ActionResult<CarWashType>> getCarWashType(string washType)
    {
        var carWashType = carWashTypes.Find(h => h.nombre == washType);
        if (carWashType == null)
        {
            return BadRequest("CarWashType not found");
        }

        return Ok(carWashType);

    }

    [HttpPost("addCarWashType")]
    public async Task<ActionResult<CarWashType>> addCarWashType(CarWashType newCarWashType)
    {
        carWashTypes.Add(newCarWashType);
        return Ok(carWashTypes);
        
    }

    [HttpPut("updateCarWashType")]
    public async Task<ActionResult<CarWashType>> updateCarWashType(CarWashType carWashTypeToUpdate)
    {
        var carWashType = carWashTypes.Find(h => h.nombre == carWashTypeToUpdate.nombre);
        if (carWashType == null)
        {
            return BadRequest("CarWashType not found");
        }

        carWashType.precio = carWashTypeToUpdate.precio;
        carWashType.costo = carWashTypeToUpdate.costo;
        carWashType.personalRequerido = carWashTypeToUpdate.personalRequerido;
        carWashType.nombre = carWashTypeToUpdate.nombre;

        return Ok(carWashTypes);
    }

    [HttpDelete("deleteCarWashType")]
    public async Task<ActionResult<CarWashType>> deleteCarWashType(string carWashTypeToDelete)
    {
        var carWashType = carWashTypes.Find(h => h.nombre == carWashTypeToDelete);
        if (carWashType == null)
        {
            return BadRequest("CarWashType not found");
        }

        carWashTypes.Remove(carWashType);
        return Ok(carWashTypes);
    }





}