using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Client.Models;

public class SignUpForm
{
    [Display(Name = "First name", Prompt = "Enter your first name")]
    public string? FirstName { get; set; }

    [Display(Name = "Last name", Prompt = "Enter your last name")]
    public string? LastName { get; set; }

    [Display(Name = "Email", Prompt = "Enter your email")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email is required")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email")]
    public string Email { get; set; } = null!;

    [Display(Name = "Password", Prompt = "Enter your password")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one lowercase letter, one uppercase letter, and one digit")]
    public string Password { get; set; } = null!;
}
