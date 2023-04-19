using AuthReference.DTO;
using AuthReference.Models;
using Microsoft.AspNetCore.Mvc;
using SecureIdentity.Password;

namespace AuthReference;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
   [HttpPost]
   public IActionResult CreateAccount([FromBody] RegisterDTO model)
   {
      if (!ModelState.IsValid)
         return BadRequest();

      var user = new User
      {
         Name = "Sidney",
         Email = model.Email
      };

      var password = PasswordGenerator.Generate(15);
      user.Password = PasswordHasher.Hash(password);

      return Ok(user);
   }
}