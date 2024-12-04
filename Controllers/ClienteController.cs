using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoVendasAPI.Data;
using ProjetoVendasAPI.Extensions;
using ProjetoVendasAPI.ViewModels;
using ProjetoVendasAPI.Models;

namespace ProjetoVendasAPI.Controllers;

public class ClienteController : ControllerBase
{
    [HttpPost]
    
    
    //          *METODO GET ALL
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
    
    //          *METODO GET BY ID
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

    [HttpPost("v1/cliente")]
    public async Task<IActionResult> PostCarrinho([FromBody] CreateClienteViewModel clienteModel,
                                                [FromServices] VendasDataContext context)
    {   
        if(!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Cliente>(ModelState.GetErrors()));

        try
        {
            var cliente = new Cliente
            {
                Id = 0,
                Nome = clienteModel.Nome,
                Cpf = clienteModel.Cpf,
                Fone = clienteModel.Fone,
                Email = clienteModel.Email,
                Senha = clienteModel.Senha,
                Endereco = clienteModel.Endereco,
                Carrinho = new Carrinho()
            };

            await context.Clientes.AddAsync(cliente);
            await context.SaveChangesAsync();

            return Created($"v1/cliente/{cliente.Id}", new ResultViewModel<Cliente>(cliente));
        }
        catch (DbUpdateException e)
        {
            return StatusCode(500, new ResultViewModel<Cliente>("05x10 - Nao foi possivel incluir o cliente."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Cliente>("05x9 - Falha interna no servidor"));
        }
    }

    //          *METODO PUT
    [HttpPut("v1/cliente/{id:int}")]
    public async Task<IActionResult> Put([FromRoute] int id,
        [FromBody] EditorClienteViewModel clienteViewModel,
        [FromServices] VendasDataContext context)
    {
        if(!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Cliente>(ModelState.GetErrors()));

        try
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

            if (cliente == null)
                return NotFound(new ResultViewModel<Cliente>("Cliente nao cadastrado!"));

            cliente.Nome = clienteViewModel.Nome;
            cliente.Cpf = clienteViewModel.Cpf;
            cliente.Fone = clienteViewModel.Fone;
            cliente.Email = clienteViewModel.Email;
            cliente.Senha = clienteViewModel.Senha;
            cliente.Endereco = clienteViewModel.Endereco;
            cliente.Carrinho = new Carrinho();

            context.Clientes.Update(cliente);
            await context.SaveChangesAsync();

            return Ok(new ResultViewModel<Cliente>(cliente));
        }
        catch (DbUpdateException e)
        {
            return StatusCode(500, new ResultViewModel<Cliente>("05x11 - Nao foi possivel atualizar o cliente."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Cliente>("05x12 - Falha interna no servidor"));
        }
    }

    //          *METODO DELETE
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
}