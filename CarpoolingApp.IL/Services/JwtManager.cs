using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CarpoolingApp.BLL.Interfaces;
using CarpoolingApp.IL.Configurations;
using Microsoft.IdentityModel.Tokens;

namespace CarpoolingApp.IL.Services {

public class JwtManager(JwtConfiguration _config, JwtSecurityTokenHandler _tokenHandler) : IJwtManager
{
    private SecurityKey SecurityKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Signature));

    public string CreateToken(string identifier, string email, string role)
    {
        DateTime now = DateTime.Now;

        JwtSecurityToken token = new(
            _config.Issuer,
            _config.Audience,
            CreateClaims(identifier, email, role),
            now,
            now.AddSeconds(_config.LifeTime),
            CreateCredentials()
        );

        return _tokenHandler.WriteToken(token);
    }

    private SigningCredentials CreateCredentials()
    {
        return new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
    }

    private static IEnumerable<Claim> CreateClaims(string identifier, string email, string role)
    {
        yield return new Claim(ClaimTypes.NameIdentifier, identifier);
        yield return new Claim(ClaimTypes.Role, role);
        yield return new Claim(ClaimTypes.Email, email);
    }
}}