using System.Security.Claims;
using ProjetoVendasAPI.Models;
namespace ProjetoVendasAPI.Extensions;

public static class CargoClaimsExtensions
{
    public static IEnumerable<Claim> Claims(this Cliente cliente)
    {
        var ClaimsList = new List<Claim>
        {
            new Claim(ClaimTypes.Name, cliente.Email),
        };
        foreach (var claims in cliente.Cargos)
        {
            ClaimsList.Add(new Claim(ClaimTypes.Role, claims.Slug));
        }
        
        return ClaimsList;
    }
}