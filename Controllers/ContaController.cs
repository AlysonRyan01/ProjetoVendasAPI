using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoVendasAPI.Data;
using ProjetoVendasAPI.Extensions;
using ProjetoVendasAPI.Models;
using ProjetoVendasAPI.Services;
using ProjetoVendasAPI.ViewModels.Contas;
using ProjetoVendasAPI.ViewModels.ResultViewModels;
using SecureIdentity.Password;

namespace ProjetoVendasAPI.Controllers;

[ApiController]
public class ContaController : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("v1/conta/cadastro")]
    public async Task<IActionResult> Register([FromBody] CreateClienteViewModel model,
        [FromServices] VendasDataContext context,
        [FromServices] EmailService email)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

        var cargoAdmin = await context.Cargos.FirstOrDefaultAsync(x => x.Id == 2);
        var cargoCliente = await context.Cargos.FirstOrDefaultAsync(x => x.Id == 1);
        
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
            
            email.Send(model.Nome, model.Email, $"Bem vindo ao nosso site {model.Nome}!", "");
            
            return Ok(new ResultViewModel<string>("Conta cadastrada com sucesso!", null));
        }
        catch (DbUpdateException e)
        {
            return StatusCode(400, new ResultViewModel<string>("005x200 - Erro no servidor"));
        }
        catch (Exception e)
        {
            return StatusCode(500, new ResultViewModel<string>("005x500 - Erro no servidor"));
        }
    }

    [AllowAnonymous]
    [HttpGet("v1/conta/logar")]
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

    [Authorize]
    [HttpPost("v1/conta/upload-image")]
    public async Task<IActionResult> UploadImage(
        [FromServices] VendasDataContext context,
        [FromBody] UploadImageViewModel model)
    {
        var fileName = $"{Guid.NewGuid().ToString()}.jpg";
        var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(model.Base64Image, "");
        var bytes = Convert.FromBase64String(data);

        try
        {
            await System.IO.File.WriteAllBytesAsync($"wwwroot/images/{fileName}", bytes);
        }
        catch (Exception e)
        {
            return StatusCode(500, new ResultViewModel<string>("05x002 - Erro no servidor"));
        }

        var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Email == User.Identity.Name);

        cliente.Imagem = $"https://localhost:0000/images/{fileName}";
        
        if (cliente == null)
            return NotFound(new ResultViewModel<string>("Usuario nao encontrado."));

        try
        {
            context.Clientes.Update(cliente);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            return StatusCode(500, new ResultViewModel<string>("05x002 - Erro no servidor"));
        }
        
        return Ok(new ResultViewModel<string>("Imagem atualizada com sucesso!", null));
    }
}