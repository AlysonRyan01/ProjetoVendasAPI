using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoVendasAPI.Data;
using ProjetoVendasAPI.Models;
using ProjetoVendasAPI.ViewModels.Contas;
using ProjetoVendasAPI.ViewModels.Contas.UpdateClienteViewModel;
using ProjetoVendasAPI.ViewModels.ResultViewModels;
using SecureIdentity.Password;

namespace ProjetoVendasAPI.Controllers;

public class ClienteController : ControllerBase
{
    [Authorize(Roles = "admin")]
    [HttpGet("v1/cliente")]
    public async Task<IActionResult> GetCliente(
        [FromServices]VendasDataContext context,
        [FromQuery] int page = 0,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var clientes = await context
                .Clientes
                .AsNoTracking()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();
            
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
    public async Task<IActionResult> GetById(
        [FromRoute] int id, 
        [FromServices] VendasDataContext context)
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
    public async Task<IActionResult> Delete(
        [FromRoute] int id, 
        [FromServices] VendasDataContext context)
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
    [HttpGet("v1/cliente/meu-perfil")]
    public async Task<IActionResult> GetPerfil(
        [FromServices] VendasDataContext context)
    {
        try
        {
            var cliente = await context
                .Clientes
                .AsNoTracking()
                .Select(x => new ClientePerfilViewModel
                {
                    Imagem = x.Imagem,
                    Nome = x.Nome,
                    Cpf = x.Cpf,
                    Fone = x.Fone,
                    Email = x.Email,
                    Endereco = x.Endereco
                })
                .FirstOrDefaultAsync(x => x.Email == User.Identity.Name);
            
            if (cliente == null)
                return NotFound(new ResultViewModel<Cliente>("Cliente nao encontrado!"));
            
            return Ok(new ResultViewModel<ClientePerfilViewModel>(cliente, null));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [Authorize]
    [HttpGet("v1/cliente/carrinho")]
    public async Task<IActionResult> Carrinho(
        [FromServices] VendasDataContext context)
    {
        try
        {
            var cliente = await context
                .Clientes
                .AsNoTracking()
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

    [Authorize]
    [HttpPut("v1/cliente/meu-perfil/alterar-email")]
    public async Task<IActionResult> AlterarEmail(
        [FromServices] VendasDataContext context,
        [FromServices] UpdateEmailViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<string>("Email nao e valido"));

        try
        {
            var cliente = await context.Clientes.AsNoTracking().FirstOrDefaultAsync(x => x.Email == User.Identity.Name);
            
            if (cliente == null)
                return NotFound(new ResultViewModel<string>("Cliente nao encontrado!"));
            
            cliente.Email = model.Email;
            
            context.Clientes.Update(cliente);
            await context.SaveChangesAsync();
            
            return Ok(new ResultViewModel<string>("E-mail atualizado com sucesso!", null));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("05X00323 - Falha interna no servidor"));
        }
    }
    
    [Authorize]
    [HttpPut("v1/cliente/meu-perfil/alterar-senha")]
    public async Task<IActionResult> AlterarSenha(
        [FromServices] VendasDataContext context,
        [FromServices] UpdateSenhaViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<string>("Senha nao e valida"));

        try
        {
            var cliente = await context.Clientes.AsNoTracking().FirstOrDefaultAsync(x => x.Email == User.Identity.Name);
            
            if (cliente == null)
                return NotFound(new ResultViewModel<string>("Cliente nao encontrado!"));
            
            if (!PasswordHasher.Verify(cliente.Senha, model.SenhaAtual))
                return StatusCode(401, new ResultViewModel<string>("senha incorreta"));
            
            cliente.Senha = PasswordHasher.Hash(model.SenhaNova);
            
            context.Clientes.Update(cliente);
            await context.SaveChangesAsync();
            
            return Ok(new ResultViewModel<string>("Senha atualizada com sucesso!", null));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Cliente>("05X00323 - Falha interna no servidor"));
        }
    }
}