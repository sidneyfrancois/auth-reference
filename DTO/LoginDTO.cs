using System.ComponentModel.DataAnnotations;

namespace AuthReference.DTO;

public class LoginDTO
{
   [Required(ErrorMessage = "e-mail is required for login")]
   [EmailAddress(ErrorMessage = "invalid e-mail address")]
   public string Email { get; set; }

   [Required(ErrorMessage = "password is required for login")]
   public string Password { get; set; }
}