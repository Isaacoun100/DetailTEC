using API.Models;
using API.RequestFromDatabase;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/")]
[ApiController]
public class ClientController: ControllerBase
{

    [HttpPost("addClient")]
    public async Task<ActionResult<StatusJSON>> addClient(Client newClient)
    {
        string name = newClient.nombreCompleto;
        Console.WriteLine(newClient.cedula);
        Console.WriteLine(newClient.nombreCompleto);
        Console.WriteLine(newClient.correo);
        ManageClients manageClients = new ManageClients();
        var savedClient = manageClients.addClient(newClient);
        Console.WriteLine("Add client: " + savedClient);
        StatusJSON json;
        if (!savedClient)
        {
            json = new StatusJSON("error", null);
            return BadRequest(json);
        }

        json = new StatusJSON("ok", newClient);
        return Ok(json);

    }
    
    [HttpGet("getAllClients")]
    public async Task<ActionResult<Client>> getAllClients()
    {
        List<Client> allClientsDB = new List<Client>();
        ManageClients manageClients = new ManageClients();
        allClientsDB = manageClients.getAllClients();
        StatusJSON json;
        if (allClientsDB.Count == 0)
        {

            json = new StatusJSON("error",null);
            return BadRequest(json);
        }

        json = new StatusJSON("ok", allClientsDB);
         return Ok(json);

    }

    [HttpPost("getClient")]
    public async Task<ActionResult<StatusJSON>> getClient(ID clientToGet)
    {
        ManageClients manageClients = new ManageClients();
        Client client = manageClients.getClient(clientToGet.cedula.ToString());
        StatusJSON result;
        if (client.cedula.Equals(""))
        {
            result = new StatusJSON("error", null);
            return BadRequest(result);
        }

        result = new StatusJSON("ok", client);
        return Ok(result);
    }

    [HttpDelete("deleteClient")]
    public async Task<ActionResult<StatusJSON>> deleteClient(ID clientToDelete)
    {
        ManageClients manageClients = new ManageClients();
        var clientDeletion = manageClients.deleteClient(clientToDelete.cedula.ToString());
        StatusJSON json;
        Console.WriteLine(clientDeletion);
        if (clientDeletion == false)
        {
            json = new StatusJSON("error", null);
            return BadRequest(json);

        }
        else {
            json = new StatusJSON("ok", "Deleted Succesfully");
            return Ok(json);
        }

    }

    [HttpPut("updateClient")]
    public async Task<ActionResult<Client>> updateClient(Client clientToUpdate)
    {
        

        ManageClients manageClients = new ManageClients();
        var updatedClient = manageClients.updateClient(clientToUpdate);
        StatusJSON json;
        if (!updatedClient)
        {
            json = new StatusJSON("error",null);
            return BadRequest(json);
        }

        json = new StatusJSON("ok", "Client Updated");
        return Ok(json);

    }
    

    

    [HttpPost("getClientPoints")]
    public async Task<ActionResult<StatusJSON>> getClientPoints(ID clientID)
    {
        ManageClients manageClients = new ManageClients();
        PointsManager pointsManager = new PointsManager();
        pointsManager = manageClients.getClientPoints(clientID.cedula.ToString());
        StatusJSON json;
        if (pointsManager.puntos == "")
        {
            json = new StatusJSON("error", null);
            return BadRequest(json);
        }

        json = new StatusJSON("ok", pointsManager);
        return Ok(json);
    }
    
    
    [HttpPost("addClientMobile")]
    public async Task<ActionResult<Client>> addClientMobile(Client newClient)
    {
        string name = newClient.nombreCompleto;
        ManageClients manageClients = new ManageClients();
        var savedClient = manageClients.addClient(newClient);
        Console.WriteLine("Add client: " + savedClient);
        if (!savedClient)
        {
            Client badClient = new Client();
            badClient.cedula = "";
            badClient.contrasena = "";
            badClient.correo = "";
            badClient.puntos = 0;
            badClient.direccion = "";
            badClient.usuario = "";
            badClient.nombreCompleto = "";
            badClient.telefonos = new List<int>();
            return BadRequest(badClient);
        }

        
        return Ok(newClient);

    }
    








}