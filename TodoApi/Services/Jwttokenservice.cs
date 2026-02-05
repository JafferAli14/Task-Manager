using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using TodoApi.models;

namespace TodoApi.Services;

public class Jwttokenservice
{
    private readonly IConfiguration _config;

    public Jwttokenservice(IConfiguration config)
    {
        _config=config;

    }
    public string createtokens(Users user)
    {
        var claims= new[]
        {
            new Claim(ClaimTypes.Name,user.username),
            
            new Claim(ClaimTypes.NameIdentifier,user.id.ToString())
        };
        
        var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));

        var creds=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

        var token= new JwtSecurityToken(
            issuer:_config["jwt:issuer"],
            audience:_config["jwt:audience"],
            claims:claims,
            signingCredentials:creds,
            expires:DateTime.Now.AddHours(1)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
