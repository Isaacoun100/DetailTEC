using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/")]
[ApiController]
public class BranchController : ControllerBase
{
    private static List<Branch> branches = new List<Branch>();


    [HttpPost("addBranch")]
    public async Task<ActionResult<Branch>> addBranch(Branch newBranch)
    {
        branches.Add(newBranch);
        return Ok(branches);

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





