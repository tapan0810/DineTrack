using DineTrack.Entities.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DineTrack.Helper.JwtHelper
{
    public class JwtHelper(IConfiguration configuration) : IJwtHelper
    {
        public string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppSettings:Token"]!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var toeknDescriptor = new JwtSecurityToken(
                
                issuer: configuration.GetValue<string>("AppSettings:issuer"),
                audience:configuration.GetValue<string>("AppSettings:audience"),
                claims: claims,
                expires:DateTime.UtcNow.AddHours(1),
                signingCredentials: creds


                );

            return new JwtSecurityTokenHandler().WriteToken(toeknDescriptor);
        }
    }
}
