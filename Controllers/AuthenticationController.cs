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
         Name = model.Name,
         Email = model.Email,
         Roles = new List<Role>()
         {
            new Role()
            {
               Name = "admin"
            },
            new Role()
            {
               Name = "author"
            }
         }
      };

      var password = PasswordGenerator.Generate(15);
      user.Password = PasswordHasher.Hash(password);

      return Ok(user);
   }

   [HttpPost("login")]
   public IActionResult Login(
      [FromServices] TokenService tokenService,
      [FromBody] LoginDTO model)
   {
      if (!ModelState.IsValid)
         return BadRequest();

      var user = new User
      {
         Name = "beltrano",
         Email = model.Email,
         Password = model.Password,
         Roles = new List<Role>()
         {
            new Role()
            {
               Name = "admin"
            },
            new Role()
            {
               Name = "author"
            }
         }
      };

      var token = tokenService.GenerateToken(user);
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