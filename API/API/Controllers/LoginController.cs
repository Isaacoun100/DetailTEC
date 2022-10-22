using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[Route("api/Auth")]
[ApiController]
public class LoginController : ControllerBase
{
    [HttpGet("get_auth")]
    public async Task<ActionResult<AuthUser>> Get()
    {
        //Metodo solamente para test, no usar 
        var webUser = new AuthUser
        {
            status = "Ok",
            result = "{" +
                     "cedula : 1122334455" +
                     "}"  
        };
        return Ok(webUser);
    }

    [HttpPost]
    public async Task<ActionResult<AuthUser>> Authenticate(Credentials credentials)
    {
        //Busca las credemciales en la base de datos, si existen en la base se debe retornar el json de la cedula
        
        var cred = new Credentials()
        {
            correo = credentials.correo,
            contrasena = credentials.contrasena
        };
        Console.WriteLine(cred.correo);
        Console.WriteLine(cred.contrasena);


        string validCredentials = "{cedula:1122334455}";
        var stat = new StatusJSON()
        {
            status = "OK",
            result = validCredentials

        };
        
       Console.WriteLine(stat.ToString());
        return Ok(stat);
    }


}