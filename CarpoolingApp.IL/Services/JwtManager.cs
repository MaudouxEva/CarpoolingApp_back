using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CarpoolingApp.BLL.Interfaces;
using CarpoolingApp.IL.Configurations;
using Microsoft.IdentityModel.Tokens;

namespace CarpoolingApp.IL.Services;

public class JwtManager : IJwtManager
{
    private readonly JwtConfiguration _config;
    private readonly JwtSecurityTokenHandler _tokenHandler;

    // constructeur explicite pour l'injection de dépendances
    public JwtManager(JwtConfiguration config)
    {
        _config = config;
        _tokenHandler = new JwtSecurityTokenHandler();
    }

    public string CreateToken(string identifier, string email, string role)
    {
        DateTime now = DateTime.Now;
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Signature));
        var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, identifier),
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role, role)
        };

        var token = new JwtSecurityToken(
            issuer: _config.Issuer,
            audience: _config.Audience,
            claims: claims,
            notBefore: now,
            expires: now.AddSeconds(_config.LifeTime),
            signingCredentials: creds
        );

        return _tokenHandler.WriteToken(token);
    }
}