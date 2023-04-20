using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthReference.Extensions;
using AuthReference.Models;
using Microsoft.IdentityModel.Tokens;

namespace AuthReference.Service;

public class TokenService
{
   public ClaimsIdentity mockClaims()
      {
         var listClaims = new ClaimsIdentity(new Claim[]
         {
            new Claim(ClaimTypes.Name, "Sidney"),
            new Claim(ClaimTypes.Role, "user"),
            new Claim(ClaimTypes.Role, "admin"),
         });

         return listClaims;
      }

   public string GenerateToken(User user)
   {
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
      var claims = user.GetClaims();
      var tokenDescriptor = new SecurityTokenDescriptor()
      {
         Subject = new ClaimsIdentity(claims),
         Expires = DateTime.UtcNow.AddHours(3),
         SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
   }
}