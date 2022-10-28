using API.Models;
using Microsoft.AspNetCore.Mvc;
using API.RequestFromDatabase;

namespace API.Controllers;

[Route("api/")]
[ApiController]
public class ProviderController : ControllerBase
{
    private static List<Provider> providers = new List<Provider>();

    [HttpPost("addProvider")]
    public async Task<ActionResult<Provider>> addProvider(Provider newProvider)
    {
        ManageProviders manageProviders = new ManageProviders();
        var addedProvider = manageProviders.addProvider(newProvider);
        StatusJSON json;
        if (!addedProvider)
        {
            json = new StatusJSON("Error", null);
            return BadRequest(json);
        }

        json = new StatusJSON("Ok", newProvider);
        return Ok(json);
    }

    [HttpPost("getProvider")]
    public async Task<ActionResult<Provider>> getProvider(ProviderID providerId)
    {
        ManageProviders manageProviders = new ManageProviders();
        Provider provider = manageProviders.getProvider(providerId.cedulaJuridica.ToString());
        StatusJSON json;
        if (provider.cedulaJuridica.Equals(0))
        {
            json = new StatusJSON("Error", null);
            return BadRequest(json);
        }

        json = new StatusJSON("Ok", provider);
        return Ok(json);
    }

    [HttpDelete("deleteProvider")]
    public async Task<ActionResult<Provider>> deleteProvider(ProviderID providerId)
    {
        ManageProviders manageProviders = new ManageProviders();
        var deletedProvider = manageProviders.deleteProvider(providerId.cedulaJuridica.ToString());
        StatusJSON json;
        if (!deletedProvider)
        {
            json = new StatusJSON("Error", null);
            return BadRequest(json);
        }

        json = new StatusJSON("Ok", "provider deleted succesfully");
        return Ok(json);
    }

    [HttpGet("getAllProviders")]
    public async Task<ActionResult<List<Provider>>> getAllProviders()
    {
        ManageProviders manageProviders = new ManageProviders();
        List<Provider> allProviders = new List<Provider>();
        allProviders = manageProviders.getAllProviders();
        StatusJSON json;
        if (allProviders.Count == 0)
        {
            json = new StatusJSON("Error", null);
            return BadRequest(json);
        }

        json = new StatusJSON("Ok", allProviders);
        return Ok(json);
    }

    [HttpPut("updateProvider")]
    public async Task<ActionResult<Provider>> updateProvider(Provider providerToUpdate)
    {
        ManageProviders manageProviders = new ManageProviders();
        var updatedProvider = manageProviders.updateProvider(providerToUpdate);
        StatusJSON json;
        if (!updatedProvider)
        {
            json = new StatusJSON("Error", null);
            return BadRequest(json);
        }

        json = new StatusJSON("Ok", "Provider updated succesfully");
        return Ok(json);

    }


}
