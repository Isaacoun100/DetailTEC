using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/")]
[ApiController]
public class ClientController: ControllerBase
{
    private static List<Client> clients = new List<Client>();


    [HttpPost("addClient")]
    public async Task<ActionResult<Client>> addClient(Client newClient)
    {
        clients.Add(newClient);
        return Ok(clients);
    }
    
    [HttpGet("getAllClients")]
    public async Task<ActionResult<Client>> getAllClients()
    {
        return Ok(clients);
    }

    [HttpPost("getClient")]
    public async Task<ActionResult<Client>> getClient(ID clientToGet)
    {
        var client = clients.Find(h => h.cedula == clientToGet.cedula);
        if (client == null)
        {
            return BadRequest("Client not found");
        }

        return Ok(client);
    }

    [HttpDelete("deleteClient")]
    public async Task<ActionResult<Client>> deleteClient(ID clientToDelete)
    {
        var client = clients.Find(h => h.cedula == clientToDelete.cedula);
        if (client==null)
        {
            return BadRequest("Client not found");
        }

        clients.Remove(client);

        return Ok(clients);


    }

    [HttpPut("updateClient")]
    public async Task<ActionResult<Client>> updateClient(Client clientToUpdate)
    {
        var client = clients.Find(h => h.cedula == clientToUpdate.cedula);
        if (client == null)
        {
            return BadRequest("Client not found");
        }

        client.nombreCompleto = clientToUpdate.nombreCompleto;
        client.telefonos = clientToUpdate.telefonos;
        client.correo = clientToUpdate.correo;
        client.direccion = clientToUpdate.direccion;
        client.usuario = clientToUpdate.usuario;
        client.contrasena = clientToUpdate.contrasena;

        return Ok(client);

    }
    










}