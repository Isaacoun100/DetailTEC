using API.Models;
using Microsoft.AspNetCore.Mvc;
using API.RequestFromDatabase;

namespace API.Controllers;

[Route("api/")]
[ApiController]
public class BranchController : ControllerBase
{
    private static List<Branch> branches = new List<Branch>();


    [HttpPost("getBranch")]
    public async Task<ActionResult<Branch>> getBranch(BranchName branchName)
    {
        ManageBranches manageBranches = new ManageBranches();
        Branch requestedBranch = manageBranches.getBranch(branchName.branchName);
        StatusJSON json;
        if (requestedBranch.nombre == "")
        {
            json = new StatusJSON("error", null);
            return BadRequest(json);

        }

        json = new StatusJSON("ok", requestedBranch);
        return Ok(json);

    }

    
    
    [HttpPost("addBranch")]
    public async Task<ActionResult<Branch>> addBranch(Branch newBranch)
    {
        ManageBranches manageBranches = new ManageBranches();
        var addedBranch = manageBranches.addBranch(newBranch);
        StatusJSON json;
        if (!addedBranch)
        {
            json = new StatusJSON("error", null);
            return BadRequest(json);

        }

        json = new StatusJSON("ok", "branch added succesfully");
        return Ok(json);

    }

    [HttpPost("deleteBranch")]
    public async Task<ActionResult<Branch>> deleteBranch(int cedulaGerente)
    {

        var deleteBranch = branches.Find(h => h.gerente == cedulaGerente);
        if (deleteBranch == null)
        {
            BadRequest("Branch not found");
        }

        branches.Remove(deleteBranch);
        return Ok(branches);

    }

    [HttpPut("updateBranch")]
    public async Task<ActionResult<Branch>> updateBranch(Branch updatedBranch)
    {
        var branch = branches.Find(h => h.gerente == updatedBranch.gerente);
        if (branch == null)
        {
            BadRequest("Branch not found");
        }

        branch.nombre = updatedBranch.nombre;
        branch.fechaInicioGerente = updatedBranch.fechaInicioGerente;
        branch.ubicacion = updatedBranch.ubicacion;
        branch.telefono = updatedBranch.telefono;

        return Ok(branches);
    }
    
    
}





