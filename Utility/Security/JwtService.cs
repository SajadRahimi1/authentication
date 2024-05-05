using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Utility.Setting;

namespace Utility.Security;

public class JwtService
{
    public static string GenerateToken(string username,string  role)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Role, role),
            new Claim(ClaimTypes.Name, username),
        };

        var token = new JwtSecurityToken(
            issuer:SandBoxManager.JwtSecretKey().Issuer,
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SandBoxManager.JwtSecretKey().SecrectKey)),
                SecurityAlgorithms.HmacSha256)
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}