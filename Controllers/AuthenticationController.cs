using AuthReference.DTO;
using Microsoft.AspNetCore.Mvc;

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

      return Ok(model);
   }
}