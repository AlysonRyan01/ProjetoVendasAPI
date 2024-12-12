using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoVendasAPI.Data;
using ProjetoVendasAPI.Models;
using ProjetoVendasAPI.ViewModels.ResultViewModels;

namespace ProjetoVendasAPI.Controllers;

public class ClienteController : ControllerBase
{
    [Authorize(Roles = "admin")]
    [HttpGet("v1/cliente")]
    public async Task<IActionResult> GetCliente([FromServices]VendasDataContext context)
    {
        try
        {
            var clientes = await context.Clientes.ToListAsync();
            
            if (clientes.Count == 0) 
                return NotFound(new ResultViewModel<Carrinho>("Nenhum cliente foi encontrado!."));
            
            return Ok(new ResultViewModel<List<Cliente>>(clientes));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<List<Carrinho>>("05x9 - Falha interna no servidor"));
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpGet("v1/cliente/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id, [FromServices] VendasDataContext context)
    {
        try
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

            if (cliente == null)
                return NotFound("Cliente nao cadastrado!");
            
            return Ok(new ResultViewModel<Cliente>(cliente));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Carrinho>("05x9 - Falha interna no servidor"));
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpDelete("v1/cliente/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id, [FromServices] VendasDataContext context)
    {
        try
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

            if (cliente == null)
                return NotFound(new ResultViewModel<Cliente>("Cliente nao cadastrado!"));

            context.Clientes.Remove(cliente);
            await context.SaveChangesAsync();

            return Ok(new ResultViewModel<Cliente>(cliente));
        }
        catch (DbUpdateException e)
        {
            return StatusCode(500, new ResultViewModel<Cliente>("05x12 - Nao foi possivel remover o cliente."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Cliente>("05x13 - Falha interna no servidor."));
        }
    }

    [Authorize]
    [HttpGet("v1/cliente/Carrinho")]
    public async Task<IActionResult> Carrinho([FromServices] VendasDataContext context)
    {
        try
        {
            var cliente = await context
                .Clientes
                .Include(x => x.Carrinho)
                    .ThenInclude(x => x.Produtos)
                .FirstOrDefaultAsync(x => x.Email == User.Identity.Name);

            if (cliente == null)
                return NotFound(new ResultViewModel<string>("Cliente nao encontrado!"));

            var carrinho = cliente.Carrinho;
            var produtosCarrinho = new List<Produto>();
            decimal valorTotalCarrinho = 0.0m;

            foreach (var produtos in carrinho.Produtos)
            {
                produtosCarrinho.Add(produtos);
                valorTotalCarrinho += produtos.Preco;
            }
            
            return Ok(new ResultCarrinhoViewModel<List<Produto>>(produtosCarrinho, valorTotalCarrinho));
        }
        catch (Exception e)
        {
            return StatusCode(500, new ResultViewModel<string>(e.Message));
        }
        
    }
}