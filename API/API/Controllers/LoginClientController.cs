using API.Models;
using API.RequestFromDatabase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;



[Route("api/")]
[ApiController]
public class LoginClientController: ControllerBase
{

    [HttpPost("loginClient")]
    public async Task<ActionResult<StatusJSON>> Authenticate(CredentialsClient credentials)
    {
        ManageClients manageClients = new ManageClients();

        Client requestedClient = manageClients.loginClient(credentials.correo, credentials.contrasena);
        StatusJSON json;
        if (requestedClient.cedula.Equals(""))
        {
            json = new StatusJSON("error", null);
            return BadRequest(json);
        }

        ID clientID = new ID();
        clientID.cedula =Int32.Parse(requestedClient.cedula);
        json = new StatusJSON("ok", clientID);
        return Ok(json);
    }

}