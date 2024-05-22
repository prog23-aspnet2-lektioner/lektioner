using System.ComponentModel.DataAnnotations;
namespace WebApp.Models;

public class SignInViewModel
{
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Enter your email")]
    [Required(ErrorMessage = "You must enter an email")]
    public string Email { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "Password", Prompt = "Enter your password")]
    [Required(ErrorMessage = "You must enter a password")]
    public string Password { get; set; } = null!;

    [Display(Name = "Remember me", Prompt = "Remember me")]
    public bool IsPresistent { get; set; }
}
