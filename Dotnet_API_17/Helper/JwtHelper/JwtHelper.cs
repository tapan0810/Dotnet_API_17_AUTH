using Dotnet_API_17.Entities.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dotnet_API_17.Helper.JwtHelper
{
    public class JwtHelper(IConfiguration configuration) : IJwtHelper
    {
        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Role,user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppSettings:Token"]!));

            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(
                issuer:configuration.GetValue<string>("AppSettings:Issuer"),
                audience:configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires:DateTime.UtcNow.AddDays(1),
                signingCredentials:creds
                );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        }
    }
}
