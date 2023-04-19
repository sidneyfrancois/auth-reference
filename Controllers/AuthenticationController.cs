using AuthReference.DTO;
using AuthReference.Models;
using AuthReference.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureIdentity.Password;

namespace AuthReference;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
   [HttpPost("register")]
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

   [HttpPost("login")]
   public IActionResult Login([FromServices] TokenService tokenService)
   {
      var token = tokenService.GenerateToken(null);
      return Ok(token);
   }

   [Authorize(Roles = "user")]
   [HttpGet("user")]
   public IActionResult GetUser() => Ok(User.Identity.Name);

   [Authorize(Roles = "admin")]
   [HttpGet("admin")]
   public IActionResult GetAdmin() => Ok(User.Identity.Name);

   [Authorize(Roles = "author")]
   [HttpGet("author")]
   public IActionResult GetAuthor() => Ok(User.Identity.Name);

}