using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/")]
[ApiController]
public class ProviderController : ControllerBase
{
    private static List<Provider> providers = new List<Provider>();

    [HttpPost("addProvider")]
    public async Task<ActionResult<Provider>> addProvider(Provider newProvider)
    {
        providers.Add(newProvider);
        return Ok(providers);
    }

    [HttpPost("getProvider")]
    public async Task<ActionResult<Provider>> getProvider(ProviderID providerId)
    {
        var provider = providers.Find(h => h.cedulaJuridica == providerId.cedulaJuridica);
        if (provider == null)
        {
            BadRequest("Provider not found");
        }

        return Ok(provider);
    }

    [HttpDelete("deleteProvider")]
    public async Task<ActionResult<Provider>> deleteProvider(ProviderID providerId)
    {
        var providerToDelete = providers.Find(h => h.cedulaJuridica == providerId.cedulaJuridica);
        if (providerId == null)
        {
            return BadRequest("Provider not found");
        }

        providers.Remove(providerToDelete);
        return Ok(providers);
    }

    [HttpPut("updateProvider")]
    public async Task<ActionResult<Provider>> updateProvider(Provider providerToUpdate)
    {
        var provider = providers.Find(h => h.cedulaJuridica == providerToUpdate.cedulaJuridica);
        if (provider == null)
        {
            return BadRequest("Provider not found");
        }

        provider.nombre = providerToUpdate.nombre;
        provider.direccion = providerToUpdate.direccion;
        provider.correo = providerToUpdate.correo;
        provider.contacto = providerToUpdate.contacto;

        return Ok(providers);
    }
    
    








}
