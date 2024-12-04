using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ProjetoVendasAPI.Services;

public class TokenService
{
    public string GenerateToken(Cliente cliente)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
        var claims = 
    }
}