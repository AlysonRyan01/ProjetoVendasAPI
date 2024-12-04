using System.Security.Claims;
using ProjetoVendasAPI.Models;
namespace ProjetoVendasAPI.Extensions;

public static class CargoClaimsExtensions
{
    public static IEnumerable<Claim> GetClaims(this Cliente cliente)
    {
        var result = new List<Claim>
        {
            new Claim(ClaimTypes.Name, cliente.Email)
        };
        result.AddRange(cliente.Cargos.Select(cargo => new Claim(ClaimTypes.Role, cargo.Slug)));
        return result;
    }
}