using Microsoft.AspNetCore.Mvc;

namespace AuthReference;

[ApiController]
public class AuthenticationController : ControllerBase
{
   [HttpPost]
   public IActionResult CreateAccount()
   {
      return Ok();
   }
}