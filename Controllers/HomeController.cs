using Microsoft.AspNetCore.Mvc;

namespace ProjetoVendasAPI.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet("/")]
    public IActionResult Get()
    {
        return Ok(new { message = "Site is running!"});                                  
    }
}