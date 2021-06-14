using System.ComponentModel.DataAnnotations;

namespace BlogLab.Model.Account
{
  public class ApplicationUserCreate : ApplicationUserLogin
  {
    [MinLength(10, ErrorMessage = "Must be at least 10-30 characters")]
    [MaxLength(30, ErrorMessage = "Must be at least 10-30 characters")]
    public string Fullname { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [MaxLength(30, ErrorMessage = "Can be at most 30 characters")]
    public string Email { get; set; }
  }
}
