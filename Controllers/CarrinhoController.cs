using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoVendasAPI.Data;
using ProjetoVendasAPI.ViewModels;
using ProjetoVendasAPI.Models;

namespace ProjetoVendasAPI.Controllers;

public class CarrinhoController : ControllerBase
{
    //          *METODO GET ALL
    [HttpGet("v1/carrinho")]
    public async Task<IActionResult> GetCarrinho([FromServices]VendasDataContext context)
    {
        try
        {
            var carrinhos = await context.Carrinhos.ToListAsync();
            
            if (carrinhos.Count == 0) 
                return NotFound(new ResultViewModel<Carrinho>("Carrinho vazio."));
            
            return Ok(new ResultViewModel<List<Carrinho>>(carrinhos));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<List<Carrinho>>("05x9 - Falha interna no servidor"));
        }
    }

    [HttpGet("v1/carrinho/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id, [FromServices] VendasDataContext context)
    {
        try
        {
            var carrinho = await context.Carrinhos.FirstOrDefaultAsync(x => x.Id == id);

            if (carrinho == null)
                return NotFound("Carrinho nao cadastrado");
            
            return Ok(new ResultViewModel<Carrinho>(carrinho));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Carrinho>("05x9 - Falha interna no servidor"));
        }
    }
}