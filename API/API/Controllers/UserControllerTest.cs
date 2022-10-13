using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserControllerTest : ControllerBase
{
    

    private readonly IWebHostEnvironment _webHostEnvironment;

    public UserControllerTest(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpGet(Name = "GetInfo")]
    public String GetLogin()
    {
        var rootPath = _webHostEnvironment.ContentRootPath;
        var fullPath = Path.Combine(rootPath, "Database.json");
        var jsonData = System.IO.File.ReadAllText(fullPath);
        return jsonData;
    }
   
}