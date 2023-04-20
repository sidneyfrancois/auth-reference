using System.Linq;
using System.Security.Claims;
using AuthReference.Models;

namespace AuthReference.Extensions;

public static class RoleClaimExtension
{
   public static IEnumerable<Claim> GetClaims(this User user)
   {
      var claims = new List<Claim>
      {
          new(ClaimTypes.Name, user.Email)
      };

      claims.AddRange(
          user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Name))
      );

      return claims;
   }
}