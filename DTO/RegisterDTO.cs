using System.ComponentModel.DataAnnotations;

namespace AuthReference.DTO;

public class RegisterDTO
{
   [Required(ErrorMessage = "name is required")]
   public string Name { get; set; }

   [Required(ErrorMessage = "e-mail is required")]
   [EmailAddress(ErrorMessage = "invalid e-mail address")]
   public string Email { get; set; }

   [Required(ErrorMessage = "password is required")]
   public string Password { get; set; }
}