using Microsoft.AspNetCore.Mvc;

namespace ASPTest2.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Login.html");
        return PhysicalFile(filePath, "text/html");
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromForm] string username, [FromForm] string password)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Wellcum.html");
        string html = await System.IO.File.ReadAllTextAsync(filePath);
        html = html.Replace("{username}", username);
        html = html.Replace("{password}", password);
        return Content(html, "text/html");
    }
}