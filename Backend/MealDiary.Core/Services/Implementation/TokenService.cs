using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MealDiary.Core.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace MealDiary.Core.Services;

public class TokenService(IConfiguration configuration, UserManager<AppUser> userManager)
    : ITokenService
{
    private readonly SymmetricSecurityKey _key = new(Encoding.UTF8.GetBytes(configuration["JWT:SigningKey"]));

    public async Task<string> CreateToken(AppUser appUser)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.NameId, appUser.UserName),
            new(JwtRegisteredClaimNames.Email, appUser.Email)
        };

        var roles = await userManager.GetRolesAsync(appUser);
        
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        
        var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7), //Just for Development
            SigningCredentials = cred,
            Issuer = configuration["JWT:Issuer"],
            Audience = configuration["JWT:Audience"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}