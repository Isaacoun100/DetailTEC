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
    public async Task<ActionResult<Branch>> deleteBranch(BranchName branchName)
    {

        ManageBranches manageBranches = new ManageBranches();
        var deletedBranch = manageBranches.deleteBranch(branchName.branchName);
        StatusJSON json;
        if (!deletedBranch)
        {
            json = new StatusJSON("error", null);
            return BadRequest(json);
        }
        json = new StatusJSON("ok", "branch deleted succesfully");
        return Ok(json);


    }

    [HttpPut("updateBranch")]
    public async Task<ActionResult<Branch>> updateBranch(Branch updatedBranch)
    {
        ManageBranches manageBranches = new ManageBranches();
        var booleanUpdate = manageBranches.updateBranch(updatedBranch);
        StatusJSON json;
        if (!booleanUpdate)
        {
            json = new StatusJSON("error", null);
            return BadRequest(json);
        }
        json = new StatusJSON("ok", "branch updated succesfully");
        return Ok(json);
    }
    
    [HttpGet("getAllBranches")]
    public async Task<ActionResult<Branch>> getAllBranches()
    {
        ManageBranches manageBranches = new ManageBranches();
        List<Branch> allBranches = manageBranches.getAllBranches();
        StatusJSON json;
        if (allBranches.Count == 0)
        {
            json = new StatusJSON("error", null);
            return BadRequest(json);
        }

        json = new StatusJSON("ok", allBranches);
        return Ok(json);
    }
}





