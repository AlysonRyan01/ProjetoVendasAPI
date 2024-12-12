using Microsoft.AspNetCore.Mvc;
using ProjetoVendasAPI.Attributes;
using ProjetoVendasAPI.ViewModels;
using ProjetoVendasAPI.ViewModels.ResultViewModels;

namespace ProjetoVendasAPI.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet("/")]
    public IActionResult Get()
    {
        return Ok(new ResultViewModel<string>("Site rodando."));
    }
}