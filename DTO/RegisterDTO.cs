using System.ComponentModel.DataAnnotations;

namespace AuthReference.DTO;

public class RegisterDTO
{
   [Required(ErrorMessage = "e-mail is required")]
   [EmailAddress(ErrorMessage = "invalid e-mail address")]
   public string Email { get; set; }

   [Required(ErrorMessage = "password is required")]
   public string Password { get; set; }
}