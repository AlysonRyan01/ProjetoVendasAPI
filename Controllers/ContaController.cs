using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using ProjetoVendasAPI.Data;
using ProjetoVendasAPI.Extensions;
using ProjetoVendasAPI.Models;
using ProjetoVendasAPI.Services;
using ProjetoVendasAPI.ViewModels;
using SecureIdentity.Password;

namespace ProjetoVendasAPI.Controllers;

[ApiController]
public class ContaController : ControllerBase
{
    [HttpPost("v1/cadastro")]
    public async Task<IActionResult> Register([FromBody] CreateClienteViewModel model,
        [FromServices] VendasDataContext context)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

        var cargoAdmin = await context.Cargos.FirstOrDefaultAsync(x => x.Id == 1);
        var cargoCliente = await context.Cargos.FirstOrDefaultAsync(x => x.Id == 2);
        
        var cliente = new Cliente();
        cliente.Nome = model.Nome;
        cliente.Cpf = model.Cpf;
        cliente.Fone = model.Fone;
        cliente.Email = model.Email;
        cliente.Endereco = model.Endereco;
        cliente.Carrinho = new Carrinho();
        cliente.Cargos = new List<Cargo> { cargoCliente };
        
        var senha = model.Senha;
        cliente.Senha = PasswordHasher.Hash(senha);

        try
        {
            await context.Clientes.AddAsync(cliente);
            await context.SaveChangesAsync();
            
            return Ok(new ResultViewModel<dynamic>(new
            {
                cliente = cliente.Email, senha
            }));
        }
        catch (DbUpdateException e)
        {
            return StatusCode(400, new ResultViewModel<string>("05x003 - Erro no banco de dados."));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<string>("0x0A002 - Erro no servidor."));
        }
    }

    [HttpGet("v1/login")]
    public async Task<IActionResult> Login([FromBody] LoginClienteViewModel model,
        [FromServices] VendasDataContext context,
        [FromServices] TokenService tokenService)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));
        

        var cliente = await context.Clientes
            .AsNoTracking()
            .Include(x => x.Cargos)
            .FirstOrDefaultAsync(x => x.Email == model.Email);
            
        if (cliente == null)
            return StatusCode(401, new ResultViewModel<string>("Email ou senha incorretos"));
            
        if (!PasswordHasher.Verify(cliente.Senha, model.Senha))
            return StatusCode(401, new ResultViewModel<string>("Email ou senha incorretos"));

        try
        {
            var token = tokenService.GenerateToken(cliente);
            return Ok(new ResultViewModel<string>(token, null));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("0x0023 - Erro no servidor"));
        }
    }
}