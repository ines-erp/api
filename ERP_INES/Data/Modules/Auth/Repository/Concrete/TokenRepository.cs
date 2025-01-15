using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ERP_INES.Data.Modules.Auth.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace ERP_INES.Data.Modules.Auth.Repository.Concrete;

public class TokenRepository : ITokenRepository
{
    private readonly IConfiguration _configuration;

    public TokenRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string CreateJwtToken(IdentityUser user, List<string> roles)
    {
        //create claims
        var claims = new List<Claim>();

        //relate claims to user email
        claims.Add(new Claim(ClaimTypes.Email, user.Email));

        //relate claims to user roles
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        //get the JWT key to generate credentials
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

        //generate credentials
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //generate the token
        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials
        );

        //return a new secutiry token handler
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}