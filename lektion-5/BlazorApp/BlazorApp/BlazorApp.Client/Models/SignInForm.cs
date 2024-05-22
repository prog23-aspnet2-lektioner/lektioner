using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Client.Models;

public class SignInForm
{
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Enter your email")]
    public string Email { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "Password", Prompt = "Enter your password")]
    public string Password { get; set; } = null!;
    public bool IsPresistent { get; set; }
}
