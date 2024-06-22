using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{

  public class RegisterDTOs
  {

    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
  }
}